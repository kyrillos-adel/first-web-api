using Lab1.Models;
using Lab1.Services;
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
    public IActionResult GetAll()
    {
        return Ok(this.studentService.GetStudents());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var student = this.studentService.GetStudentById(id);
        
        if (student == null)
        {
            return NotFound();
        }
        
        return Ok(student);
    }
    
    [HttpGet("{name:alpha}")]
    public IActionResult GetById(string name)
    {
        var students = this.studentService.GetStudentByName(name);
        
        return Ok(students);
    }
    
    [HttpPost]
    public IActionResult Create(Student student)
    {
        if(this.studentService.AddStudent(student))
        {
            return CreatedAtAction($"/api/student/{student.Id}", student);
        }
        return BadRequest();
    }
    
    [HttpPut("{id:int}")]
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
    public IActionResult Delete(int id)
    {   
        if (this.studentService.DeleteStudent(id)) return NoContent();
        
        return BadRequest();
    }
    
    [HttpPatch("{id:int}/UpdateName")]
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