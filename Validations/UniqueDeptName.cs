using System.ComponentModel.DataAnnotations;
using Lab1.Models;

namespace Lab1.Validations;

public class UniqueDeptNameAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var dbContext = (SDbContext)validationContext.GetService(typeof(SDbContext));
        
        string departmentName = value as string;
        if (!string.IsNullOrEmpty(departmentName))
        {
            string? deptNameIfExists = dbContext.Departments
                .FirstOrDefault(x => x.Name == departmentName)?.Name;
            
            if (deptNameIfExists != null)
            {
                return new ValidationResult("Department name already exists");
            }
        }
        
        return ValidationResult.Success;
    }
}