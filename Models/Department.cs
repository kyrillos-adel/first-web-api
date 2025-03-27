using System.ComponentModel.DataAnnotations;
using Lab1.Validations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Lab1.Models;

public class Department : IType
{
    public int Id { get; set; }
    
    [UniqueDeptName]
    public string Name { get; set; }
    
    [RegularExpression(@"^(EG|USA|Bucharest|Cluj)$", ErrorMessage = "Allowed locations are EG and USA")]
    public string Location { get; set; }
    public string? ManagerName { get; set; }
    
    public virtual ICollection<Student>? Students { get; set; }
}