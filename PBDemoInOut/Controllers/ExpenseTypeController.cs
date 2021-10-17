using Microsoft.AspNetCore.Mvc;
using PBDemoInOut.Data;
using PBDemoInOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBDemoInOut.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDBContext _db;
        public ExpenseTypeController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           IEnumerable<ExpenseType> objList = _db.ExpenseTypes;
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
        public IActionResult Create(ExpenseType Obj)
        {
            if(ModelState.IsValid)
            {
                _db.ExpenseTypes.Add(Obj);
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
            var obj = _db.ExpenseTypes.Find(id);
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
           
                var obj = _db.ExpenseTypes.Find(id);
                if (obj==null)
                {
                    return NotFound();

                }
                _db.ExpenseTypes.Remove(obj);
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
            var obj = _db.ExpenseTypes.Find(id);
            if (obj == null)
            {
                return NotFound();

            }
            return View(obj);

        }

        //POST create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseType Obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Update(Obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(Obj);
        }

    }
}
