using Microsoft.AspNetCore.Mvc;
using Employeeproject.Models;

namespace Employeeproject.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDbContext dbContext;
        public EmployeeController(EmployeeDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            return View(dbContext.Employees.ToList());
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usser u)
        {
            string uname = u.UserName;
            string password = u.Password;

            var usersList = dbContext.Ussers.ToList();

            Usser us = dbContext.Ussers.SingleOrDefault(x => x.UserName== uname && x.Password==password);
            if (us == null)
            {
                ViewBag.Message = "Invalid Username or Password";
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            dbContext.Employees.Add(obj);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            Employee obj = dbContext.Employees.Find(id);
            return View(obj);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee obj = dbContext.Employees.Find(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            dbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee obj = dbContext.Employees.Find(id);
            return View(obj);
        }
        /*[HttpPost]
        public IActionResult Delete(int id)/* Overloading error as same method name with same number and type of arguments to avoid this change datatype of argument or use action name*/
        /*{
            Student obj = dbContext.Students.Find(id);
            dbContext.Students.Remove(obj); 
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }*/
        /* (1) Changing type of argument
        [HttpPost]
        public IActionResult Delete(string id)
        {
            Student obj = dbContext.Students.Find(int.Parse(id));
            dbContext.Students.Remove(obj); 
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        /* (2) Using Action Name*/
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            Employee obj = dbContext.Employees.Find(id);
            dbContext.Employees.Remove(obj);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        /*[HttpGet]
        public IActionResult DepartmentList()
        {
            
            return View();
        }*/
        [HttpGet]
        public IActionResult DepartmentDetails()
        {
            List<string> depdetails=dbContext.Employees.Select(x=>x.Department).Distinct().ToList();
            ViewBag.DepartmentDetails = depdetails;
            return View();
        }
        [HttpGet]
        public IActionResult EmpsByDept(string id) 
        {
            ViewBag.dept = id;
            List<Employee> empList = dbContext.Employees.Where(x => x.Department == id).ToList();
            ViewBag.Emps = empList;
            return View();
        }
    }
}
