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
            return View(objList.OrderBy(objList => objList.DueDate).Take(10).ToList());
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
            if (ModelState.IsValid)
            {
                _context.Expenses.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj); 
        }


        //GET UPDATE
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }


        //POST UPDATE
        public IActionResult UpdatePost(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);

        }


        //GET DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Expenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        //POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _context.Expenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
