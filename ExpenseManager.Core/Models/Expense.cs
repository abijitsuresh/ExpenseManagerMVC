using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Core.Models
{
    public class Expense
    {
        public int ExpenseID { get; set; }
        [Required()]
        [StringLength(200, MinimumLength = 2)]
        public string ExpenseName { get; set; }
        [Required()]
        [DataType(DataType.Currency)]
        public string ExpenseAmount { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
