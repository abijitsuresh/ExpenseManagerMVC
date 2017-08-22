using ExpenseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.DAL.Repositories
{
    public class UserRepository : Repository<User>
    {
        public List<User> GetUsers()
        {
            return DbSet.ToList();
        }
    }
}
