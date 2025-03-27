using Lab1.Models;

namespace Lab1.Repositories;

public class DepartmentRepository
{
    private readonly SDbContext sdContext;
    
    public DepartmentRepository(SDbContext dbContext)
    {
        this.sdContext = dbContext;
    }

    public List<Department> GetDepartments()
    {
        return sdContext.Departments.ToList();
    }
    
    public Department GetDepartmentById(int id)
    {
        return sdContext.Departments.FirstOrDefault(d => d.Id == id);
    }
    
    public Department GetDepartmentByName(string name)
    {
        return sdContext.Departments.FirstOrDefault(d => d.Name == name);
    }
    
    public bool AddDepartment(Department department)
    {
        sdContext.Departments.Add(department);
        return sdContext.SaveChanges() > 0;
    }
    
    public bool UpdateDepartment(Department department)
    {
        sdContext.Departments.Update(department);
        return sdContext.SaveChanges() > 0;
    }
    
    public bool DeleteDepartment(int id)
    {
        var department = GetDepartmentById(id);
        
        if (department == null)
        {
            return false;
        }
        
        sdContext.Departments.Remove(department);
        return sdContext.SaveChanges() > 0;
    }
}