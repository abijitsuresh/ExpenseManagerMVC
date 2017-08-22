using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManager.Core;
using ExpenseManager.Core.Interfaces;
using System.Data.Entity;
using ExpenseManager.Core.Models;

namespace ExpenseManager.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private bool disposed = false;
        private ExpenseManagerDataContext context = null;

        protected DbSet<T> DbSet
        {
            get; set;
        }

        public Repository()
        {
            context = new ExpenseManagerDataContext();
            DbSet = context.Set<T>();
        }

        public Repository(ExpenseManagerDataContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public T GetByID(int id)
        {
            return DbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }        

        public void Update(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if(!disposed)
            {
                context.Dispose();
                disposed = true;
            }
        }
    }
}
