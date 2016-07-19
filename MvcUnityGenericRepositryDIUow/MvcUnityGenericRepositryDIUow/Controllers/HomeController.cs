using MvcUnityGenericRepositryDIUow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUnityGenericRepositryDIUow.Service;
using MvcUnityGenericRepositryDIUow.DAL;

namespace MvcUnityGenericRepositryDIUow.Controllers
{
    public class HomeController : Controller
    {
        private IService<Student> service;

        
        public HomeController(IService<Student> service) 
        {
            this.service = service;            
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult NewStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewStudent(Student student)
        {
            service.Add(student);
            return RedirectToAction("Students");
        }

        public ActionResult Students()
        {
            return View(service.Get());
        }

        public ActionResult Student(int id)
        {
            var result = service.FindByID(id);
            return View(result);
        }

        public ActionResult StudentIndex()
        {
            return View();
        }

        public ActionResult AddStudent()
        {

            return View();
        }
    }
}
