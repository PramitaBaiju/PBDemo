using Microsoft.AspNetCore.Mvc;
using PBDemoInOut.Data;
using PBDemoInOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBDemoInOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDBContext _db;
        public ExpenseController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           IEnumerable<Expense> objList = _db.Expenses;
            return View(objList);
           
        }
        //Get create
        public IActionResult Create()
        {

            return View();

        }

        //POST create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense Obj)
        {
            if(ModelState.IsValid)
            {
                //Obj.ExpenseTypeId = 1;
                _db.Expenses.Add(Obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
          return View(Obj);
        }



        //Get Delete
        public IActionResult Delete(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();

            }
            return View(obj);

        }
    

    //Post Delete
    [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
           
                var obj = _db.Expenses.Find(id);
                if (obj==null)
                {
                    return NotFound();

                }
                _db.Expenses.Remove(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
                     
        }

        //Get  Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();

            }
            return View(obj);

        }

        //POST create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense Obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(Obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(Obj);
        }

    }
}
