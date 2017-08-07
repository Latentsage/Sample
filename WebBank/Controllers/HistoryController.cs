using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBank.Models;

namespace WebBank.Controllers
{
    public class HistoryController : Controller
    {
        // GET: History
        public ActionResult Index()
        {
            var bank = BankSingleton.GetBank();
            HistoryModel model = new HistoryModel() { Transactions = bank.LoggedInAccount.Transactions.ToList(), Balance = bank.LoggedInAccount.Balance };
            return View(model);
        }
    }
}