using Lab1.Filters;
using Lab1.Models;
using Lab1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService departmentService;
        
        public DepartmentController(DepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
    
        [HttpGet]
        [HeaderResultFilter]
        public IActionResult GetAll()
        {
            return Ok(this.departmentService.GetDepartments());
        }
    
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var department = this.departmentService.GetDepartmentById(id);
            
            if (department == null)
            {
                return NotFound();
            }
            
            return Ok(department);
        }
        
        [HttpGet("{name:alpha}")]
        public IActionResult GetById(string name)
        {
            var department = this.departmentService.GetDepartmentByName(name);
            
            return Ok(department);
        }
        
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if(this.departmentService.AddDepartment(department))
            {
                return CreatedAtAction(nameof(GetById), new {department.Id}, department);
            }
            return BadRequest();
        }

        [HttpPost("createv2")]
        [ValidateLocationFilter("Bucharest, Cluj")]
        public IActionResult CreateV2(Department department)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if(this.departmentService.AddDepartment(department))
            {
                return CreatedAtAction(nameof(GetById), new {department.Id}, department);
            }
            return BadRequest();
        }
        
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }
            
            if (departmentService.UpdateDepartment(department)) return NoContent();
    
            return Conflict();
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {   
            if (this.departmentService.DeleteDepartment(id)) return NoContent();
            
            return BadRequest();
        }
    }
}
