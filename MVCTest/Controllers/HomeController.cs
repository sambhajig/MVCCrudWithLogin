using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTest.DB.DbOperation;
using MVCTest.Model;
using Newtonsoft.Json;

namespace MVCTest.Controllers
{
   [Authorize]
    public class HomeController : Controller
    {


        EmployeeRepository repository = null;
        public HomeController()
        {
            repository = new EmployeeRepository();
        }


        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddEmp()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public ActionResult AddEmp(EmployeeModel model)
        {
            if(ModelState.IsValid)
            {
                int id = repository.AddEmployee(model);
                if(id>0)
                {
                    ModelState.Clear();
                    ViewBag.msg = "Data Added";
                }
                
            }
            return View();
        }

        public ActionResult GetAllEmp()
        {
            var result = repository.GetAllEmployees();
            return View(result);
        }

        public ActionResult GetSingleEmp(int id)
        {

            var result = repository.GetSingleEmp(id);
            return View(result);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditEmp(int id)
        {
            var result = repository.GetSingleEmp(id);
            return View(result);
           
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditEmp(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateEmp(model.Id, model);

                return RedirectToAction("GetAllEmp");
            }
            return View();

        }

        //public ActionResult DeleteEmp()
        //{
        //    return View();
        //}

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteEmp(int id)
        {
            repository.DeleteEmp(id);

            return RedirectToAction("GetAllEmp");
        }

        public JsonResult JsonTest()
        {
          var data=  repository.GetAllEmployees();

            var json = JsonConvert.SerializeObject(data);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult SaveEmp(EmployeeModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        int id = repository.AddEmployee(model);
        //    }
        //    return Json("Data Added", JsonRequestBehavior.AllowGet);
        //}
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}