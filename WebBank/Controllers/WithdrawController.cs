using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBank.Models;

namespace WebBank.Controllers
{
    public class WithdrawController : Controller
    {
        // GET: Withdraw
        public ActionResult Index()
        {
            return View(new WithdrawalModel());
        }

        // POST: Withdraw
        [HttpPost]
        public ActionResult Index(WithdrawalModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BankSingleton.GetBank().LoggedInAccount.Withdraw(model.Amount);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}