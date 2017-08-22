using ExpenseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.DAL
{
    public class ExpenseManagerDataContextInitializer : DropCreateDatabaseAlways<ExpenseManagerDataContext>
    {
        protected override void Seed(ExpenseManagerDataContext context)
        {
            User user = new User() { Name = "Abijit", EmailID = "abijit.suresh@outlook.com", Password = "20080201", MobileNumber = "832-551-4070" };

            context.Users.Add(user);

            Expense expense = new Expense() { ExpenseName = "Grocery", ExpenseAmount = "11.22", User = user };
            context.Expenses.Add(expense);

            Income income = new Income() { IncomeName = "DailySalary", IncomeAmount = "250", User = user };
            context.Incomes.Add(income);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
