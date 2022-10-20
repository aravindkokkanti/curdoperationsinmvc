using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace curdoperationsinmvc.Controllers
{
    public class HomeController : Controller
    {
        TutorialsCS _context = new TutorialsCS();
        public ActionResult Index()
        {
            
            var listofData = _context.EMPLOYEs.ToList();
            return View(listofData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EMPLOYE model)
        {
            _context.EMPLOYEs.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.EMPLOYEs.Where(x => x.EmployId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(EMPLOYE Model)
        {
            var data = _context.EMPLOYEs.Where(x => x.EmployId == Model.EmployId).FirstOrDefault();
            if (data != null)
            {
                data.EmployCity = Model.EmployCity;
                data.EmployName = Model.EmployName;
                data.EmploySalary = Model.EmploySalary;
                _context.SaveChanges();
            }

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = _context.EMPLOYEs.Where(x => x.EmployId == id).FirstOrDefault();

            _context.EMPLOYEs.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }

        public ActionResult Details(int id)
        {
            var data = _context.EMPLOYEs.Where(x => x.EmployId == id).FirstOrDefault();
            return View(data);
        }


    }
 }