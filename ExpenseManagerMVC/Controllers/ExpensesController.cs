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
    public class ExpensesController : Controller
    {
        //private ExpenseManagerDataContext db = new ExpenseManagerDataContext();
        ExpenseRepository expenseRepository = new ExpenseRepository();
        UserRepository userRepository = new UserRepository();

        // GET: Expenses
        public ActionResult Index()
        {
            return View(expenseRepository.GetAll());
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int id)
        {
            Expense expense = expenseRepository.GetByID(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(userRepository.GetUsers(), "UserID", "Name");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpenseID,ExpenseName,ExpenseAmount,UserID")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                expenseRepository.Add(expense);
                expenseRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(userRepository.GetUsers(), "UserID", "Name", expense.UserID);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int id)
        {
            Expense expense = expenseRepository.GetByID(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(userRepository.GetUsers(), "UserID", "Name", expense.UserID);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpenseID,ExpenseName,ExpenseAmount,UserID")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                expenseRepository.Update(expense);
                expenseRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(userRepository.GetUsers(), "UserID", "Name", expense.UserID);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int id)
        {
            Expense expense = expenseRepository.GetByID(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            
            expenseRepository.Delete(id);
            expenseRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                expenseRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
