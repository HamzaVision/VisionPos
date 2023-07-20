using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VisionPos.Data;
using VisionPos.Models.ViewModels;

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
            return View(_db.Customers.Include(x => x.CustomerTypes).ToList());
        }

        public IActionResult Create()
        {

            CustomerCustomerTypeListViewModel mod = new CustomerCustomerTypeListViewModel()
            {
                Customer = new Models.Customer(),
                CustomersList = _db.CustomerTypes.Select(a => new SelectListItem()
                { Text = a.CustomerType, Value = a.Id.ToString() }).ToList(),
                //CustomersNameList = _db.Customers.Select(a => new SelectListItem()
                //{ Text = a.Name, Value = a.Id.ToString() }).ToList()

            };

            return View("CreateAndEdit", mod);

        }



        public IActionResult Edit(int id)
        {
            var cus = _db.CustomerTypes.FirstOrDefault(x => x.Id == id);
            return View("CreateAndEdit", cus);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CustomerCustomerTypeListViewModel obj)
        {
            var cus = _db.Customers.Where(x => x.Name == obj.Customer.Name);
            if (cus != null)
            {
                return View("CreateAndEdit", obj);
            }

            obj.Customer.CreationDate = DateTime.Now;
            _db.Customers.Add(obj.Customer);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
