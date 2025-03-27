using Lab1.Models;

namespace Lab1.Repositories;

public class StudentRepository
{
    private readonly SDbContext dbContext;

    public StudentRepository(SDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public List<Student> GetStudents()
    {
        return dbContext.Students.ToList();
    }
    
    public Student GetStudentById(int id)
    {
        return dbContext.Students.FirstOrDefault(d => d.Id == id);
    }
    
    public ICollection<Student> GetStudentByName(string name)
    {
        return dbContext.Students.Where(s => s.Name.StartsWith(name)).ToList();
    }
    
    public bool AddStudent(Student Student)
    {
        dbContext.Students.Add(Student);
        return dbContext.SaveChanges() > 0;
    }
    
    public bool UpdateStudent(Student Student)
    {
        dbContext.Students.Update(Student);
        return dbContext.SaveChanges() > 0;
    }
    
    public bool DeleteStudent(int id)
    {
        var Student = GetStudentById(id);
        
        if (Student == null)
        {
            return false;
        }
        
        dbContext.Students.Remove(Student);
        return dbContext.SaveChanges() > 0;
    } 
}