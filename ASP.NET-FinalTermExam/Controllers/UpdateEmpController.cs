using ASP.NET_FinalTermExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_FinalTermExam.Controllers
{
    public class UpdateEmpController : Controller
    {
        DB db = new DB();
        // GET: UpdateEmp
        public ActionResult Index(String empId)
        {
            Employees data =  db.Employees.Find(Convert.ToInt32(empId));
            ViewBag.data = data;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection input) {
            String empId =  input["empId"];
            String empFirstName = input["empFirstName"];
            String empLastName = input["empLastName"];
            String empTitle = input["empTitle"];
            String empTitleName = input["empTitleName"];
            String empHireDate = input["empHireDate"];
            String empBirthDate = input["empBirthDate"];
            String empCountry = input["empCountry"];
            String empCity = input["empCity"];
            String empAddress = input["empAddress"];
            String empPhone = input["empPhone"];
            String empGender = input["empGender"];
            String empManagerID = input["empManagerID"];
            String empMonthlyPayment = input["empMonthlyPayment"];
            String empYearlyPayment = input["empYearlyPayment"];

            return RedirectToAction("Result",new { empId, empFirstName, empLastName, empTitle, empTitleName, empHireDate, empBirthDate,
                empCountry, empCity, empAddress,empPhone,empGender,empManagerID,empMonthlyPayment,empYearlyPayment
            });
        }
        public ActionResult Result(String empId, String empFirstName, String empLastName, String empTitle, String empTitleName, String empHireDate,
             String empBirthDate, String empCountry, String empCity, String empAddress, String empPhone, String empGender, String empManagerID, 
             String empMonthlyPayment, String empYearlyPayment)
        {

            Employees data = db.Employees.Find(Convert.ToInt32(empId));

            data.FirstName = empFirstName;
            data.LastName = empLastName;
            data.Title = empTitle;
            data.TitleOfCourtesy = empTitleName;
            data.HireDate = Convert.ToDateTime(empHireDate);
            data.BirthDate = Convert.ToDateTime(empBirthDate);
            data.Country = empCountry;
            data.City = empCity;
            data.Address = empAddress;
            data.Phone = empPhone;
            data.Gender = empGender;
            data.ManagerID = Convert.ToInt32(empManagerID);
            data.MonthlyPayment = Convert.ToInt32(empMonthlyPayment);
            data.YearlyPayment = Convert.ToInt32(empYearlyPayment);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public void delete(String empId) {
            Employees data = db.Employees.Find(Convert.ToInt32(empId));

            db.Employees.Remove(data);
            db.SaveChanges();
        }
    }
}