using CrudAppusingAdo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudAppusingAdo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            EmployeeDbContext db = new EmployeeDbContext();
            List<Employee> obj = db.GetEmployees();

            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {         
            if(ModelState.IsValid==true)
            {
                EmployeeDbContext context=new EmployeeDbContext();
                bool check =context.AddEmployees(emp);
                if(check==true)
                {
                    TempData["insertMessage"] = "Data has been inserted Successfully";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
                return View();
            }
            catch (Exception ex) 
            {
                return View();
            }
           
        }
        public ActionResult Edit(int id)
        {
           
            EmployeeDbContext context = new EmployeeDbContext();
            var row = context.GetEmployees().Find(model => model.id == id);
            return View(row);

        }

        [HttpPost]
        public ActionResult Edit(int id,Employee emp)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDbContext context = new EmployeeDbContext();
                    bool check = context.UpdateEmployees(emp);
                    if (check == true)
                    {
                        TempData["updateEmployee"] = "Data has been updated Successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        public ActionResult Details(int id)
        {

            EmployeeDbContext context = new EmployeeDbContext();
            var row = context.GetEmployees().Find(model => model.id == id);
            return View(row);

        }
        public ActionResult Delete(int id)
        {

            EmployeeDbContext context = new EmployeeDbContext();
            var row = context.GetEmployees().Find(model => model.id == id);
            return View(row);

        }
        [HttpPost]
        public ActionResult Delete(int id, Employee emp)
        {        
                    EmployeeDbContext context = new EmployeeDbContext();
                    bool check = context.DeleteEmployee(id);
                    if (check == true)
                    {
                        TempData["deleteEmployee"] = "Data has been Deleted Successfully";
                        return RedirectToAction("Index");
                    }              
                return View();
        }
    }
}