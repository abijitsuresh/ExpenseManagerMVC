using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        List<T> GetAll();
        T GetByID(int id);
        void Delete(int id);
    }
}
