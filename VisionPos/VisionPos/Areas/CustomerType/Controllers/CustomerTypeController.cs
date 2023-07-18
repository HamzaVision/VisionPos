using Microsoft.AspNetCore.Mvc;
using VisionPos.Data;

namespace VisionPos.Areas.CustomerType.Controllers
{
    [Area("CustomerType")]
    public class CustomerTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CustomerTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.CustomerTypes.ToList());
        }
    }
}
