using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;


namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ExpenseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _context.Expenses;
            return View(objList);
        }


        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }


        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)
        {
            _context.Expenses.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
