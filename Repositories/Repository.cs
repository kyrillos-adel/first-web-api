using Lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Repositories;

public class Repository <T> where T : class, IType
{
    private readonly SDbContext sdContext;
    private readonly DbSet<T> dbSet;
    
    public Repository(SDbContext dbContext)
    {
        this.sdContext = dbContext;
        dbSet = sdContext.Set<T>();
    }

    public List<T> Get()
    {
        return dbSet.ToList();
    }
    
    public T GetById(int id)
    {
        return dbSet.FirstOrDefault(d => d.Id == id);
    }
    
    public T GetByName(string name)
    {
        return dbSet.FirstOrDefault(d => d.Name == name);
    }
    
    public int Add(T t)
    {
        dbSet.Add(t);
        sdContext.SaveChanges();

        return t.Id;
    }
    
    public bool Update(T t)
    {
        dbSet.Update(t);
        return sdContext.SaveChanges() > 0;
    }
    
    public bool Delete(int id)
    {
        var t = GetById(id);
        
        if (t == null)
        {
            return false;
        }
        
        dbSet.Remove(t);
        return sdContext.SaveChanges() > 0;
    }
}