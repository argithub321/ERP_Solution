using DatabaseLayer;
using ERP_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_App.Controllers
{
    public class EmployeeController : Controller
    {
        BussinessERPDbEntities1 DB = new BussinessERPDbEntities1();
        // GET: Employee
        public ActionResult BranchEmployees()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var userid = 0;
            var usertypeid = 0;
            var companyid = 0;
            var branchid = 0;
            var branchtypeid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeid);
            int.TryParse(Convert.ToString(Session["CompanyID"]), out companyid);
            int.TryParse(Convert.ToString(Session["BranchID"]), out branchid);
            int.TryParse(Convert.ToString(Session["BranchTypeID"]), out branchtypeid);
            var employees = DB.tblEmployees.Where(e => e.CompanyID == companyid && e.BranchID == branchid).ToList();
            var list = new List<EmployeeMV>();
            foreach (var employee in employees)
            {
                list.Add(new EmployeeMV()
                {
                    Address = employee.Address,
                    BranchID = employee.BranchID,
                    CNIC = employee.CNIC,
                    CompanyID = employee.CompanyID,
                    ContactNo = employee.ContactNo,
                    Description = employee.Description,
                    Designation = employee.Designation,
                    Email = employee.Email,
                    EmployeeID = employee.EmployeeID,
                    MonthlySalary = employee.MonthlySalary,
                    Name = employee.Name,
                    Photo = employee.Photo,
                    UserID = employee.UserID
                });
            }
            return View(list);
        }

        public ActionResult NewBranchEmployee()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var userid = 0;
            var usertypeid = 0;
            var companyid = 0;
            var branchid = 0;
            var branchtypeid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeid);
            int.TryParse(Convert.ToString(Session["CompanyID"]), out companyid);
            int.TryParse(Convert.ToString(Session["BranchID"]), out branchid);
            int.TryParse(Convert.ToString(Session["BranchTypeID"]), out branchtypeid);
            var employee = new EmployeeMV();
            employee.CompanyID = companyid;
            employee.BranchID = branchid;
            employee.UserID = 0;
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewBranchEmployee(EmployeeMV employeemv)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var userid = 0;
            var usertypeid = 0;
            var companyid = 0;
            var branchid = 0;
            var branchtypeid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeid);
            int.TryParse(Convert.ToString(Session["CompanyID"]), out companyid);
            int.TryParse(Convert.ToString(Session["BranchID"]), out branchid);
            int.TryParse(Convert.ToString(Session["BranchTypeID"]), out branchtypeid);

            try
            {
                if (ModelState.IsValid)
                {
                    var checkemployee = DB.tblEmployees.Where(e => e.CNIC == employeemv.CNIC.Trim()).FirstOrDefault();
                    if (checkemployee == null)
                    {
                        var newemployee = new tblEmployee();
                        newemployee.Address = employeemv.Address;
                        newemployee.BranchID = branchid;
                        newemployee.CNIC = employeemv.CNIC;
                        newemployee.CompanyID = companyid;
                        newemployee.ContactNo = employeemv.ContactNo;
                        newemployee.Description = employeemv.Description;
                        newemployee.Designation = employeemv.Designation;
                        newemployee.Email = employeemv.Email;
                        newemployee.MonthlySalary = employeemv.MonthlySalary;
                        newemployee.Name = employeemv.Name;
                        newemployee.Photo = "~/Content/Template/img/user/employee.png";
                        newemployee.UserID = employeemv.UserID;
                        DB.tblEmployees.Add(newemployee);
                        DB.SaveChanges();
                        return RedirectToAction("BranchEmployees");
                    }
                    else
                    {
                        ModelState.AddModelError("CNIC", "Already Exist!");
                    }
                }
                return View(employeemv);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Name", "Must be Filled All Field with correct data!");
                return View(employeemv);
            }
        }

        public ActionResult EditBranchEmployee(int? employeeid)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var userid = 0;
            var usertypeid = 0;
            var companyid = 0;
            var branchid = 0;
            var branchtypeid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeid);
            int.TryParse(Convert.ToString(Session["CompanyID"]), out companyid);
            int.TryParse(Convert.ToString(Session["BranchID"]), out branchid);
            int.TryParse(Convert.ToString(Session["BranchTypeID"]), out branchtypeid);
            var employee = DB.tblEmployees.Find(employeeid);
            var editemployee = new EmployeeMV();
            editemployee.Address = employee.Address;
            editemployee.BranchID = employee.BranchID;
            editemployee.CNIC = employee.CNIC;
            editemployee.CompanyID = employee.CompanyID;
            editemployee.ContactNo = employee.ContactNo;
            editemployee.Description = employee.Description;
            editemployee.Designation = employee.Designation;
            editemployee.Email = employee.Email;
            editemployee.EmployeeID = employee.EmployeeID;
            editemployee.MonthlySalary = employee.MonthlySalary;
            editemployee.Name = employee.Name;
            editemployee.Photo = employee.Photo;
            editemployee.UserID = employee.UserID;
            return View(editemployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBranchEmployee(EmployeeMV employeemv)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var userid = 0;
            var usertypeid = 0;
            var companyid = 0;
            var branchid = 0;
            var branchtypeid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            int.TryParse(Convert.ToString(Session["UserTypeID"]), out usertypeid);
            int.TryParse(Convert.ToString(Session["CompanyID"]), out companyid);
            int.TryParse(Convert.ToString(Session["BranchID"]), out branchid);
            int.TryParse(Convert.ToString(Session["BranchTypeID"]), out branchtypeid);

            try
            {
                if (ModelState.IsValid)
                {
                    var checkemployee = DB.tblEmployees.Where(e => e.CNIC == employeemv.CNIC.Trim() && e.EmployeeID != employeemv.EmployeeID).FirstOrDefault();
                    if (checkemployee == null)
                    {
                        var editemployee = DB.tblEmployees.Find(employeemv.EmployeeID);
                        editemployee.Address = employeemv.Address;
                        editemployee.CNIC = employeemv.CNIC;
                        editemployee.ContactNo = employeemv.ContactNo;
                        editemployee.Description = employeemv.Description;
                        editemployee.Designation = employeemv.Designation;
                        editemployee.Email = employeemv.Email;
                        editemployee.MonthlySalary = employeemv.MonthlySalary;
                        editemployee.Name = employeemv.Name;
                        //newemployee.Photo = "~/Content/Template/img/user/employee.png";
                        DB.Entry(editemployee).State = System.Data.Entity.EntityState.Modified;
                        DB.SaveChanges();
                        return RedirectToAction("BranchEmployees");
                    }
                    else
                    {
                        ModelState.AddModelError("CNIC", "Already Exist!");
                    }
                }
                return View(employeemv);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Name", "Must be Filled All Field with correct data!");
                return View(employeemv);
            }
        }
    }
}