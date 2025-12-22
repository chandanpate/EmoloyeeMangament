using System.Threading.Tasks;
using EmployeeManagement.Binddb;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeeManagement.Controllers
{
    public class Dashboard : Controller
    {
        private readonly BusinessData _context;
        public Dashboard(BusinessData context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Emp_Dashboard() {

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

        public async Task<IActionResult> Editdata(int id, Models.Empdata empdata)
        {
            var editdata= await _context.Empdata.FindAsync(id);
            if (editdata==null)
            {
                return NotFound();
            }
            _context.Empdata.Update(editdata);
            await _context.SaveChangesAsync();

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
        public IActionResult Logindata(Models.LoginModel login)
        {
            if (login.Username == "admin" && login.Password == "1234")
            {
                return RedirectToAction("Emp_Dashboard");

            }
            return RedirectToAction("Login");


        }

    }
}
