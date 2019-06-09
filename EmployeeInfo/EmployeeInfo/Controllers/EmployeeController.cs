using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeInfo.Models;

namespace EmployeeInfo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEmpData()
        {
            using (EmpDBConn db = new EmpDBConn())
            {
                List<Employee> empList= db.Employees.ToList<Employee>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }

        
        public ActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmpDetail(Employee emp)
        {
            using (EmpDBConn db = new EmpDBConn())
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Record Saved Successfully", JsonRequestBehavior.AllowGet });
            }
        }

        public ActionResult DeleteEmployee(int id)
        {
            using (EmpDBConn db = new EmpDBConn())
            {
               Employee emp=  db.Employees.Where(x => x.ID == id).FirstOrDefault<Employee>();
                db.Employees.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Record deleted succcessfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}