
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Santa_MVC.Models;

namespace Santa_MVC.Controllers
{
    public class ReindeerController : Controller
    {
        private readonly IConfiguration _configuration;
        private ReindeerModel _reindeerModel { get; set; }

        public ReindeerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ReindeerModel reindeerModel = new ReindeerModel(_configuration);
            ViewBag.ReindeerTable = reindeerModel.GetAllReindeers();
            return View();
        }

        
        public IActionResult InsertReindeer(int rNr, string rClanName, string rSubspecies, string rName, string rStink, string rRegion, int rGroupBellonging)
        {
            ReindeerModel reindeerModel = new ReindeerModel(_configuration);
            reindeerModel.InsertReindeer(rNr, rClanName, rSubspecies, rName, rStink, rRegion, rGroupBellonging);

            return RedirectToAction("Index");
        }
    }
}


