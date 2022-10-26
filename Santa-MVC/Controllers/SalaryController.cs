using Microsoft.AspNetCore.Mvc;
using Santa_MVC.Models;

namespace Santa_MVC.Controllers
{
    public class SalaryController : Controller
    {
        private readonly IConfiguration _configuration;

        
        public SalaryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            SalaryModel sm = new SalaryModel(_configuration);
            ViewBag.SalaryTable = sm.GetSalary();
            return View();
        }
    }
}
