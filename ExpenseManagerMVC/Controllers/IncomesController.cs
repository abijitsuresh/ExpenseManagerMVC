using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExpenseManager.Core.Models;
using ExpenseManager.DAL;
using ExpenseManager.DAL.Repositories;

namespace ExpenseManagerMVC.Controllers
{
    public class IncomesController : Controller
    {
        //private ExpenseManagerDataContext db = new ExpenseManagerDataContext();

        private IncomeRepository incomeRepository = new IncomeRepository();
        private UserRepository userRepository = new UserRepository();

        // GET: Incomes
        public ActionResult Index()
        {
            return View(incomeRepository.GetAll());
        }

        // GET: Incomes/Details/5
        public ActionResult Details(int id)
        {
            Income income = incomeRepository.GetByID(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        // GET: Incomes/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(userRepository.GetUsers(), "UserID", "Name");
            return View();
        }

        // POST: Incomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IncomeID,IncomeName,IncomeAmount,UserID")] Income income)
        {
            if (ModelState.IsValid)
            {
                incomeRepository.Add(income);
                incomeRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(userRepository.GetUsers(), "UserID", "Name", income.UserID);
            return View(income);
        }

        // GET: Incomes/Edit/5
        public ActionResult Edit(int id)
        {
            Income income = incomeRepository.GetByID(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(userRepository.GetUsers(), "UserID", "Name", income.UserID);
            return View(income);
        }

        // POST: Incomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IncomeID,IncomeName,IncomeAmount,UserID")] Income income)
        {
            if (ModelState.IsValid)
            {
                incomeRepository.Update(income);
                incomeRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(userRepository.GetUsers(), "UserID", "Name", income.UserID);
            return View(income);
        }

        // GET: Incomes/Delete/5
        public ActionResult Delete(int id)
        {
            Income income = incomeRepository.GetByID(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        // POST: Incomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            incomeRepository.Delete(id);
            incomeRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                incomeRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
