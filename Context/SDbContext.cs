using Microsoft.EntityFrameworkCore;
namespace Lab1.Models;

public class SDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }
    
    public SDbContext(DbContextOptions<SDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Department>().HasData(
            
            new Department
            {
                Id = 1,
                Name = "Computer Science",
                Location = "EG",
                ManagerName = "John Doe"
            },
            new Department
            {
                Id = 2,
                Name = "Mathematics",
                Location = "USA",
                ManagerName = "Jane Smith"
            },
            new Department
            {
                Id = 3,
                Name = "Physics",
                Location = "USA",
                ManagerName = "Alice Johnson"
            },
            new Department
            {
                Id = 4,
                Name = "Chemistry",
                Location = "EG",
                ManagerName = "Bob Brown"
            }
        );
        
        // Seed products with images
        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                Id = 1,
                Name = "John Smith",
                Age = 32,
                Address = "123 Main St, New York, NY",
                ImageUrl = "https://example.com/images/john-smith.jpg",
                Birthdate = new DateOnly(1991, 5, 15),
                DepartmentId = 1
            },
            new Student
            {
                Id = 2,
                Name = "Emily Johnson",
                Age = 28,
                Address = "456 Oak Ave, Los Angeles, CA",
                ImageUrl = "https://example.com/images/emily-johnson.jpg",
                Birthdate = new DateOnly(1995, 8, 22),
                DepartmentId = 2
            },
            new Student
            {
                Id = 3,
                Name = "Michael Brown",
                Age = 45,
                Address = "789 Pine Rd, Chicago, IL",
                ImageUrl = null, // No image available
                Birthdate = new DateOnly(1978, 11, 3),
                DepartmentId = 3
            },
            new Student
            {
                Id = 4,
                Name = "Sarah Davis",
                Age = 24,
                Address = "321 Elm Blvd, Houston, TX",
                ImageUrl = "https://example.com/images/sarah-davis.png",
                Birthdate = new DateOnly(1999, 2, 18),
                DepartmentId = 4
            }
        );
    }
}