using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Core.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Required()]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        [Required()]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailID { get; set; }
        [Required()]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required()]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        public virtual List<Expense> Expenses { get; set; }
        public virtual List<Income> Incomes { get; set; }
    }
}
