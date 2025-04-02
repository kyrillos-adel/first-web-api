using Lab1.Filters;
using Lab1.Models;
using Lab1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly StudentService studentService;
    private readonly SDbContext context;
    
    public StudentController(StudentService studentService, SDbContext context)
    {
        this.studentService = studentService;
        this.context = context;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAll()
    {
        return Ok(this.studentService.GetStudents());
    }

    [HttpGet("{id:int}")]
    [Authorize(Roles = "Student")]
    [ValidateUserFilter]
    public IActionResult GetById(int id)
    {
        // if (User.FindFirst("StudentId")?.Value != id.ToString())
        // {
        //     return Unauthorized();
        // }
        
        var student = this.studentService.GetStudentById(id);
        
        if (student == null)
        {
            return NotFound();
        }
        
        return Ok(student);
    }
    
    [HttpGet("{name:alpha}")]
    [Authorize(Roles = "Student")]
    public IActionResult GetByName(string name)
    {
        var students = this.studentService.GetStudentByName(name);
        
        return Ok(students);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create(Student student)
    {
        if(this.studentService.AddStudent(student) > 0)
        {
            return CreatedAtAction($"/api/student/{student.Id}", student);
        }
        return BadRequest();
    }
    
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin,Student")]
    public IActionResult Update(int id, [FromBody] Student student)
    {
        if (id != student.Id)
        {
            return BadRequest();
        }
        
        if (studentService.UpdateStudent(student)) return NoContent();

        return Conflict();
    }
    
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {   
        if (this.studentService.DeleteStudent(id)) return NoContent();
        
        return BadRequest();
    }
    
    [HttpPatch("{id:int}/UpdateName")]
    [Authorize(Roles = "Admin,Student")]
    public IActionResult UpdateName(int id, [FromBody] string newName)
    { 
        Student student = context.Students.Find(id);
        if (student == null)
        {
            return NotFound();
        }
        student.Name = newName;
        
        this.context.SaveChanges();
        
        return NoContent();
    }
}