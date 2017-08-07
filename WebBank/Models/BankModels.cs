using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebBank.Models
{
    public class DepositModel
    {
        [Required]
        [Display(Name = "Amount")]
        [Range(0, double.MaxValue)]
        public double Amount { get; set; }
    }

    public class WithdrawalModel
    {
        [Required]
        [Display(Name = "Amount")]
        [Range(0, double.MaxValue)]
        public double Amount { get; set; }
    }

    public class HistoryModel
    {
        [Required]
        [Display(Name = "Transactions")]
        public List<double> Transactions { get; set; }

        [Required]
        [Display(Name = "Balance")]
        public double Balance { get; set; }
    }
}