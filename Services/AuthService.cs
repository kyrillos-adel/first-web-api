using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lab1.DTOs.AuthDTO;
using Lab1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Lab1.Services;

public class AuthService
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly JWT jwt;
    private readonly StudentService studentService;

    public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration, StudentService studentService)
    {
        this.userManager = userManager;
        this.jwt = configuration.GetSection("JWT").Get<JWT>();
        this.studentService = studentService;
    }

    public async Task<AuthModel> RegisterAsync(RegisterDto model)
    {
        if (await this.userManager.FindByEmailAsync(model.Email) is not null)
            return new AuthModel { Message = "Email is already registered!" };

        if (await this.userManager.FindByNameAsync(model.Username) is not null)
            return new AuthModel { Message = "Username is already registered!" };

        var newStudentId  = studentService.AddStudent(new Student()
        {
            Name = $"{model.FirstName} {model.LastName}"
        });
        
        var user = new ApplicationUser
        {
            StudentId = newStudentId,
            UserName = model.Username,
            Email = model.Email,
            Name = $"{model.FirstName} {model.LastName}",
        };

        var result = await this.userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            var errors = string.Empty;
            foreach (var error in result.Errors)
                errors += $"{error.Description},";

            return new AuthModel { Message = errors };
        }

        await this.userManager.AddToRoleAsync(user, "Student");

        var jwtSecurityToken = await CreateJwtToken(user);

        return new AuthModel
        {
            Email = user.Email,
            ExpiresOn = jwtSecurityToken.ValidTo,
            IsAuthenticated = true,
            Roles = new List<string> { "Student" },
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Username = user.UserName
        };
    }

    public async Task<AuthModel> LoginAsync(LoginDto model)
    {
        var authModel = new AuthModel();

        var user = await this.userManager.FindByEmailAsync(model.Email);

        if (user is null || !await this.userManager.CheckPasswordAsync(user, model.Password))
        {
            authModel.Message = "Email or Password is incorrect!";
            return authModel;
        }

        var jwtSecurityToken = await CreateJwtToken(user);
        var rolesList = await this.userManager.GetRolesAsync(user);

        authModel.IsAuthenticated = true;
        authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        authModel.Email = user.Email;
        authModel.Username = user.UserName;
        authModel.ExpiresOn = jwtSecurityToken.ValidTo;
        authModel.Roles = rolesList.ToList();

        return authModel;
    }

    private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
    {
        var userClaims = await this.userManager.GetClaimsAsync(user);
        var roles = await this.userManager.GetRolesAsync(user);
        var roleClaims = new List<Claim>();

        foreach (var role in roles)
            roleClaims.Add(new Claim("roles", role));

        var claims = new[]
        {
            new Claim("StudentId", user.StudentId.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
        }
        .Union(userClaims)
        .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.jwt.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: this.jwt.Issuer,
            audience: this.jwt.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(this.jwt.DurationInDays),
            signingCredentials: signingCredentials);

        return jwtSecurityToken;
    }
}