using Lab1.Models;
using Lab1.DTOs.DepartmentDTO;
using Lab1.Repositories;

namespace Lab1.Services;

public class DepartmentService
{
    #region Normal Repsitory
    /*private readonly DepartmentRepository departmentRepository;
    
    public DepartmentService(DepartmentRepository departmentRepository)
    {
        this.departmentRepository = departmentRepository;
    }
    
    public List<DepartmentDto> GetDepartments()
    {
        var departments = departmentRepository.GetDepartments();
        var departmentDtos = new List<DepartmentDto>();
        foreach (var department in departments)
        {
            departmentDtos.Add(new DepartmentDto
            {
                Name = department.Name,
                ManagerName = department.ManagerName,
                StudentsNames = department.Students.Select(s => s.Name).ToList(),
                StudentsCount = department.Students.Count,
                Message = department.Students.Count > 2 ? "This department is crowded"
                : "This department is not crowded"
            });
        }
        return departmentDtos;
    }
    
    public DepartmentDto GetDepartmentById(int id)
    {
        var department = departmentRepository.GetDepartmentById(id);
        var departmentDto = new DepartmentDto
        {
            Name = department.Name,
            ManagerName = department.ManagerName,
            StudentsNames = department.Students.Select(s => s.Name).ToList(),
            StudentsCount = department.Students.Count,
            Message = department.Students.Count > 2 ? "This department is crowded"
                : "This department is not crowded"
        };
        
        return departmentDto;
    }
    
    public DepartmentDto GetDepartmentByName(string name)
    {
        var department = departmentRepository.GetDepartmentByName(name);
        var departmentDto = new DepartmentDto
        {
            Name = department.Name,
            ManagerName = department.ManagerName,
            StudentsNames = department.Students.Select(s => s.Name).ToList(),
            StudentsCount = department.Students.Count,
            Message = department.Students.Count > 2 ? "This department is crowded"
                : "This department is not crowded"
        };
        
        return departmentDto;
    }
    
    public bool AddDepartment(Department department)
    {
        return departmentRepository.AddDepartment(department);
    }
    
    public bool UpdateDepartment(Department department)
    {
        return departmentRepository.UpdateDepartment(department);
    }
    
    public bool DeleteDepartment(int id)
    {
        return departmentRepository.DeleteDepartment(id);
    }*/
    #endregion
    
    #region Generic Repository
    private readonly Repository<Department> repository;
    
    public DepartmentService(Repository<Department> repository)
    {
        this.repository = repository;
    }
    
    public List<DepartmentDto> GetDepartments()
    {
        var departments = repository.Get();
        var departmentDtos = new List<DepartmentDto>();
        foreach (var department in departments)
        {
            departmentDtos.Add(new DepartmentDto
            {
                Name = department.Name,
                ManagerName = department.ManagerName,
                StudentsNames = department.Students.Select(s => s.Name).ToList(),
                StudentsCount = department.Students.Count,
                Message = department.Students.Count > 2 ? "This department is crowded"
                : "This department is not crowded"
            });
        }
        return departmentDtos;
    }
    
    public DepartmentDto GetDepartmentById(int id)
    {
        var department = repository.GetById(id);
        var departmentDto = new DepartmentDto
        {
            Name = department.Name,
            ManagerName = department.ManagerName,
            StudentsNames = department.Students.Select(s => s.Name).ToList(),
            StudentsCount = department.Students.Count,
            Message = department.Students.Count > 2 ? "This department is crowded"
                : "This department is not crowded"
        };
        
        return departmentDto;
    }
    
    public DepartmentDto GetDepartmentByName(string name)
    {
        var department = repository.GetByName(name);
        var departmentDto = new DepartmentDto
        {
            Name = department.Name,
            ManagerName = department.ManagerName,
            StudentsNames = department.Students.Select(s => s.Name).ToList(),
            StudentsCount = department.Students.Count,
            Message = department.Students.Count > 2 ? "This department is crowded"
                : "This department is not crowded"
        };
        
        return departmentDto;
    }
    
    public int AddDepartment(Department department)
    {
        return repository.Add(department);
    }
    
    public bool UpdateDepartment(Department department)
    {
        return repository.Update(department);
    }
    
    public bool DeleteDepartment(int id)
    {
        return repository.Delete(id);
    }
    #endregion
}