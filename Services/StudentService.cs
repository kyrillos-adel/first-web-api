using Lab1.DTOs.StudentDTO;
using Lab1.Models;
using Lab1.Repositories;

namespace Lab1.Services;

public class StudentService
{
    #region Normal Repository
    /*private readonly StudentRepository studentRepository;

    public StudentService(StudentRepository studentRepository)
    {
        this.studentRepository = studentRepository;
    }
    
    public List<StudentDto> GetStudents()
    {
        var students = studentRepository.GetStudents();
        var studentDtos = new List<StudentDto>();
        foreach (var student in students)
        {
            studentDtos.Add(new StudentDto
            {
                Name = student.Name,
                Address = student.Address,
                DepartmentName = student.Department.Name,
                Skills = new List<string>()
                {
                    "C#",
                    "Java"
                }
            });
        }
        return studentDtos;
    }
    
    public StudentDto GetStudentById(int id)
    {
        var student = studentRepository.GetStudentById(id);
        var studentDto = new StudentDto
        {
            Name = student.Name,
            Address = student.Address,
            DepartmentName = student.Department.Name,
            Skills = new List<string>()
            {
                "C#",
                "Java"
            }
        };
        
        return studentDto;
    }
    
    public ICollection<StudentDto> GetStudentByName(string name)
    {
        var students = studentRepository.GetStudentByName(name);
        var studentDtos = new List<StudentDto>();
        
        foreach (var student in students)
        {
            studentDtos.Add(new StudentDto
            {
                Name = student.Name,
                Address = student.Address,
                DepartmentName = student.Department.Name,
                Skills = new List<string>()
                {
                    "C#",
                    "Java"
                }
            });
        }
        
        return studentDtos;
    }
    
    public bool AddStudent(Student student)
    {
        return studentRepository.AddStudent(student);
    }
    
    public bool UpdateStudent(Student student)
    {
        return studentRepository.UpdateStudent(student);
    }
    
    public bool DeleteStudent(int id)
    {
        return studentRepository.DeleteStudent(id);
    }*/
    #endregion
    
    #region Generic Repository
    private readonly Repository<Student> repository;
    
    public StudentService(Repository<Student> repository)
    {
        this.repository = repository;
    }
    
    public List<StudentDto> GetStudents()
    {
        var students = repository.Get();
        var studentDtos = new List<StudentDto>();
        foreach (var student in students)
        {
            studentDtos.Add(new StudentDto
            {
                Name = student.Name,
                Address = student.Address,
                DepartmentName = student.Department.Name,
                Skills = new List<string>()
                {
                    "C#",
                    "Java"
                }
            });
        }
        return studentDtos;
    }
    
    public StudentDto GetStudentById(int id)
    {
        var student = repository.GetById(id);
        var studentDto = new StudentDto
        {
            Name = student.Name,
            Address = student.Address,
            DepartmentName = student.Department.Name,
            Skills = new List<string>()
            {
                "C#",
                "Java"
            }
        };
        
        return studentDto;
    }
    
    public StudentDto GetStudentByName(string name)
    {
        var student = repository.GetByName(name);
        var studentDto = new StudentDto()
        {
            Name = student.Name,
            Address = student.Address,
            DepartmentName = student.Department.Name,
            Skills = new List<string>()
            {
                "C#",
                "Java"
            }
        };
        
        return studentDto;
    }
    
    public int AddStudent(Student student)
    {
        return repository.Add(student);
    }
    
    public bool UpdateStudent(Student student)
    {
        return repository.Update(student);
    }
    
    public bool DeleteStudent(int id)
    {
        return repository.Delete(id);
    }
    #endregion
}