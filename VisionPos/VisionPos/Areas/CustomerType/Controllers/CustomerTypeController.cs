using Microsoft.AspNetCore.Mvc;
using VisionPos.Data;
using VisionPos.Models;
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

        public IActionResult Create()
        {
            var cus = new CustomerTypes();
            return View("CreateAndEdit", cus);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerTypes obj)
        {
            obj.CreationDate = DateTime.Now;
            _db.CustomerTypes.Add(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
