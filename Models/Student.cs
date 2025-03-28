using System.Net.Mime;

namespace Lab1.Models;

public class Student : IType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Age { get; set; }
    public string? Address { get; set; }
    public string? ImageUrl { get; set; }
    public DateOnly Birthdate { get; set; }
    
    public int? DepartmentId { get; set; }
    public virtual Department? Department { get; set; }
}