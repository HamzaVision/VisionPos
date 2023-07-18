using Microsoft.AspNetCore.Mvc;
using VisionPos.Data;

namespace VisionPos.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Customers.ToList());
        }
    }
}
