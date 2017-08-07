using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBank.Models;

namespace WebBank.Controllers
{
    public class DepositController : Controller
    {
        // GET: Deposit
        public ActionResult Index()
        {
            return View(new DepositModel());
        }

        // POST: Deposit
        [HttpPost]
        public ActionResult Index(DepositModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BankSingleton.GetBank().LoggedInAccount.Deposit(model.Amount);
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