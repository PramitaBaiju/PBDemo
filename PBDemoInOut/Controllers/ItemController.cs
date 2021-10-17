using Microsoft.AspNetCore.Mvc;
using PBDemoInOut.Data;
using PBDemoInOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBDemoInOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDBContext _db;
        public ItemController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
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
        public IActionResult Create(Item Obj)
        {
            _db.Items.Add(Obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
