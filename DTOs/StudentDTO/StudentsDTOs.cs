using System.ComponentModel.DataAnnotations;

namespace Lab1.DTOs.StudentDTO;

public class CreateStudentDto
{
    [StringLength(100)]
    public string Name { get; set; }
    
    [Range(1, 60)]
    public int Age { get; set; }
    
    public string Address { get; set; }
    
    public string? ImageUrl { get; set; }
    
    public DateOnly Birthdate { get; set; }
    
    public int DepartmentId { get; set; }
}

public class UpdateStudentDto
{
    [Required]
    int Id { get; set; }
    
    [StringLength(100)]
    public string Name { get; set; }
    
    [Range(1, 60)]
    public int Age { get; set; }
    
    public string Address { get; set; }
    
    public string? ImageUrl { get; set; }
    
    public int DepartmentId { get; set; }
}

public class StudentDto
{
    public string Name { get; set; }

    public string Address { get; set; }
    
    public string DepartmentName { get; set; }
    
    public ICollection<string> Skills { get; set; }
}