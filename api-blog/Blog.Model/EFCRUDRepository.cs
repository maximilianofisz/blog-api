using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Model
{
    // Cool class to inherit from in repo design pattern, this would definitely be placed in an internal NuGet along with other usefull classes
    public abstract class EFCRUDRepository<T> where T : class
    {
        protected DbContext dbContext;

        public EFCRUDRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public abstract DbSet<T> GetDBSet();

        public IEnumerable<T> FindAll()
        {
            return GetDBSet().ToList();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public T FindById(int id)
        {
            return GetDBSet().Find(id);
        }

        public T Save(T entity)
        {
            return GetDBSet().Add(entity).Entity;
        }

        public T Update(T entity)
        {
            return GetDBSet().Update(entity).Entity;
        }

        public void Delete(T entity)
        {
            GetDBSet().Remove(entity);
        }

        public void DeleteById(int id)
        {
            GetDBSet().Remove(FindById(id));
        }
    }
}
