using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTest.Model;
using MVCTest.DB;
using MVCTest.DB.DbOperation;
using System.Dynamic;

namespace MVCTest.Controllers
{
    public class TestController : Controller
    {
        EmployeeRepository repository = new EmployeeRepository();
        AccountOperation operation = new AccountOperation();
        // GET: Test
        public ActionResult Index()
        {
         //1   //passing multiple model in single view using viewModel
            IndexVM model = new IndexVM();
          
            var Emp = repository.GetAllEmployees();
            var user = operation.GetAllUser();

            model.Employees = Emp;
            model.User = user;

          //2  ///dynamic model

            //dynamic modeldata = new ExpandoObject();
            //modeldata.Employee = Emp;
            //modeldata.User = user;


         //3   //using Tuple
           // var model1 = new Tuple<List<UserModel>, List<EmployeeModel>>(user,Emp);

            return View(model);
        }
    }
}