using System.Diagnostics;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    //[HttpPut("{id}")]
    //    public async Task<IActionResult> UpdateProduct(int id, Product product)
    //    {
    //        if (id != product.Id)
    //            return BadRequest();

    //        _context.Entry(product).State = EntityState.Modified;
    //        await _context.SaveChangesAsync();
    //        return Ok(product);
    //    }

    //    // DELETE
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> DeleteProduct(int id)
    //    {
    //        var product = await _context.Products.FindAsync(id);
    //        if (product == null)
    //            return NotFound();

    //        _context.Products.Remove(product);
    //        await _context.SaveChangesAsync();
    //        return Ok();
    //    }
    //}
}
