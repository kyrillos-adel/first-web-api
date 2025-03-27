using System.ComponentModel.DataAnnotations;
using Lab1.Validations;

namespace Lab1.DTOs.DepartmentDTO;

public class CreateDepartmentDto
{
    [UniqueDeptName]
    public string Name { get; set; }
    
    [RegularExpression(@"^(EG|USA)$", ErrorMessage = "Allowed locations are EG and USA")]
    public string Location { get; set; }
    
    public string ManagerName { get; set; }
}

public class UpdateDepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string ManagerName { get; set; }
}

public class DepartmentDto
{
    public string Name { get; set; }
    
    public string ManagerName { get; set; }
    
    public virtual ICollection<string> StudentsNames { get; set; }
    
    public int StudentsCount { get; set; }

    public string Message { get; set; }
}