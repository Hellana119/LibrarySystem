using LibrarySystem.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.Repos.GenericRepo;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly LibraryContext _context;

    public GenericRepo(LibraryContext context)
    {
        _context = context;
    }
    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }
    public async Task Add(T entity)
    {
        _context.Set<T>().Add(entity);
         await _context.SaveChangesAsync();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }



    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }


}
