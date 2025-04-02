using Microsoft.AspNetCore.Identity;

namespace Lab1.Models;

public class ApplicationUser : IdentityUser
{
    public int? StudentId { get; set; }
    public string Name { get; set; }
}