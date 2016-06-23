using ASP.NET_FinalTermExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_FinalTermExam.Controllers
{
    public class SearchEmpController : Controller
    {
        DB db = new DB();

        // GET: SearchEmp
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection inputs) {

            String empId = inputs["empId"];
            String empName = inputs["empName"];
            String empTitle = inputs["empTitle"];
            String empHireDateStart = inputs["empHireDateStart"];
            String empHireDateEnd = inputs["empHireDateEnd"];

            return RedirectToAction("Result", new { empId , empName , empTitle , empHireDateStart , empHireDateEnd });
        }

        public ActionResult Result(String empId, String empName, String empTitle, String empHireDateStart, String empHireDateEnd) {

            DateTime HireDateStart = Convert.ToDateTime(empHireDateStart);
            DateTime HireDateEnd = Convert.ToDateTime(empHireDateEnd);
            //DateTime HireDate = new DateTime();

            List<Employees> data = db.Employees.Where(x =>
                (String.IsNullOrEmpty(empId) ? true : x.EmployeeID.ToString().Equals(empId)) &&
                (String.IsNullOrEmpty(empName) ? true : x.FirstName.Equals(empName)) &&
                (String.IsNullOrEmpty(empTitle) ? true : x.Title.Equals(empTitle))
            ).ToList();
            
            //foreach (var item in data)
            //{
            //    if (HireDateStart.Year <= item.HireDate.Year || HireDateEnd.Year >= item.HireDate.Year) {
            //        if (HireDateStart.Month <= item.HireDate.Month || HireDateEnd.Month >= item.HireDate.Month) {
            //            if (HireDateStart.Day <= item.HireDate.Day || HireDateEnd.Day >= item.HireDate.Day)
            //            {
            //                HireDate = item.HireDate;
            //            }
            //        }
            //    }
            //}

            ViewBag.data = data;
            return View();
        }

        public void delete(int empId)
        {
            Employees data = db.Employees.Find(empId);

            db.Employees.Remove(data);
            db.SaveChanges();
        }
    }
}