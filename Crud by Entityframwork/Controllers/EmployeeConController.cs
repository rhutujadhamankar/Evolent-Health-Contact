using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud_by_Entityframwork.Models;

namespace Crud_by_Entityframwork.Controllers
{
    
    public class EmployeeConController : Controller
    {
        s3sdevsqlEntities db = new s3sdevsqlEntities();
        // GET: Employee
        public ActionResult Index()
        { 
            return View(db.tblContactDetails.ToList());
        }
        public ActionResult RegistrationForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrationForm(tblContactDetail emp)
        {
            if(ModelState.IsValid)
            {
                emp.IsActive = true;
                db.tblContactDetails.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }
        public ActionResult EditForm(int id)
        {
            tblContactDetail data = db.tblContactDetails.FirstOrDefault(m => m.Personid.Equals(id));
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditForm(tblContactDetail emp)
        {
            tblContactDetail olddata = db.tblContactDetails.FirstOrDefault(m => m.Personid.Equals(emp.Personid));
            olddata.Personid = emp.Personid;
            olddata.FirstName = emp.FirstName;
            olddata.LastName = emp.LastName;
            olddata.PhoneNumber = emp.PhoneNumber;
            olddata.Email = emp.Email;
            olddata.IsActive = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult InactiveEmp(int id)
        {
            tblContactDetail olddata = db.tblContactDetails.FirstOrDefault(m => m.Personid.Equals(id));
            olddata.IsActive = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}