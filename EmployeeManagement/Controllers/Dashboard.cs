using System.Threading.Tasks;
using EmployeeManagement.Binddb;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeeManagement.Controllers
{
    public class Dashboard : Controller
    {
        private readonly BusinessData _context;
        public readonly ILogger<Dashboard> _logger;
        public Dashboard(BusinessData context,ILogger<Dashboard>logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Emp_Dashboard() {

            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
                return RedirectToAction("Login");

            var showdata = await _context.Empdata.ToListAsync();
            return View(showdata);
        }

        public IActionResult Add_Empdata()
        {
            return View();
        }
        public async Task<IActionResult> Save_Empdata(Models.Empdata empdata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empdata);
                await _context.SaveChangesAsync();
                return RedirectToAction("Emp_Dashboard");
            }
            return View("Add_Empdata", empdata);
        }

        [HttpGet("Edit_Empdata/{id}")]
        public async Task<IActionResult> Edit_Empdata(int id)
        {
            var data = await _context.Empdata.FindAsync(id);
            
            return View(data);
        }
        [HttpGet("Delete_Empdata/{id}")]

        public async Task<IActionResult> Delete_Empdata(int id) {

            var data = await _context.Empdata.FindAsync(id);
        return View(data);
        }
        
        [HttpPost("Edit_Empdata/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editdata(int id, Models.Empdata empdata)
        {
            var editdata= await _context.Empdata.FindAsync(id);
            if (editdata==null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    editdata.Emp_FristName = empdata.Emp_FristName;
                    editdata.Emp_LastName = empdata.Emp_LastName;
                    editdata.Emp_EmailId = empdata.Emp_EmailId;
                    editdata.Emp_Dept = empdata.Emp_Dept;
                    editdata.Emp_PhoneNo = empdata.Emp_PhoneNo;
                    editdata.Emp_Position = empdata.Emp_Position;
                    editdata.Emp_Salary = empdata.Emp_Salary;
                    _context.Empdata.Update(editdata);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                   throw ex;
                }
               
            }
            

            return RedirectToAction("Emp_Dashboard");
        }

        [HttpPost("Delete_Empdata/{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            var emp = await _context.Empdata.FindAsync(id);
            if (emp == null)
                return NotFound();

            _context.Empdata.Remove(emp);
            await _context.SaveChangesAsync();
            return RedirectToAction("Emp_Dashboard");
        }

        public IActionResult Login()
        {
            return View(new LoginModel());
        }
        
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Logindata(Models.LoginModel login)
        {
            if (login ==null)
            {
                _logger.LogWarning("Login attempt with null model.");

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View("Login", new Models.LoginModel());
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var User = _context.loginmodels.FirstOrDefault(u => u.UserId == login.UserId && u.Password == login.Password);
                    if (User!=null)
                    {
                        HttpContext.Session.SetString("IsAuthenticated", "true");

                        return RedirectToAction("Emp_Dashboard");

                    }
                    else
                    {
                        _logger.LogWarning("Failed login for user {UserId}.", login.UserId,login.Password);
                        ModelState.AddModelError(string.Empty, "Invalid username or password.");


                    }
                }
                catch (Exception ex)
                {
                   
                    throw ex;
                }
            }
            return View("Login", login);



        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            var user = HttpContext.Session.GetString("UserId") ?? "unknown";
            HttpContext.Session.Clear();
            _logger.LogInformation("User {UserId} logged out.", user);
            return RedirectToAction("Login");
        }
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("Login");
        //}
    }
}
