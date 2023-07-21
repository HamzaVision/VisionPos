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
            var cus = _db.Customers.FirstOrDefault(x => x.Id == id);
            CustomerCustomerTypeListViewModel mod = new CustomerCustomerTypeListViewModel()
            {
                Customer = cus,
                CustomersList = _db.CustomerTypes.Select(a => new SelectListItem()
                { Text = a.CustomerType, Value = a.Id.ToString() }).ToList(),
                //CustomersNameList = _db.Customers.Select(a => new SelectListItem()
                //{ Text = a.Name, Value = a.Id.ToString() }).ToList()

            };

            return View("CreateAndEdit", mod);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CustomerCustomerTypeListViewModel obj)
        {

            if (!_db.Customers.Any(x => x.Name == obj.Customer.Name))
            {
                obj.Customer.CreationDate = DateTime.Now;
                _db.Customers.Add(obj.Customer);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            TempData["DangerMessage"] = "This Name is Already Exists in the Data Base.";
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

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerCustomerTypeListViewModel obj)
        {
            var sub = await _db.Customers.FirstOrDefaultAsync(x => x.Id == obj.Customer.Id);
            if (sub.Name == obj.Customer.Name)
            {
                sub.CustomerType = obj.Customer.CustomerType;
                sub.Address = obj.Customer.Address;
                sub.PhoneNumber = obj.Customer.PhoneNumber;
                sub.IsActive = obj.Customer.IsActive;
                sub.CreationDate = DateTime.Now;
                _db.Customers.Update(sub);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else if (sub.Name != obj.Customer.Name && !_db.Customers.Any(x => x.Name == obj.Customer.Name))
            {
                sub.Name = obj.Customer.Name;
                sub.CustomerType = obj.Customer.CustomerType;
                sub.Address = obj.Customer.Address;
                sub.PhoneNumber = obj.Customer.PhoneNumber;
                sub.IsActive = obj.Customer.IsActive;
                sub.CreationDate = DateTime.Now;
                _db.Customers.Update(sub);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            TempData["DangerMessage"] = "This Name is Already Exists in the Data Base.";
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

        [HttpGet]
        public IActionResult GetcustomerDetails(int id)
        {
            var customer = _db.Customers.Include(x => x.CustomerTypes).FirstOrDefault(x => x.Id == id);
            return PartialView("_CustomerDetailsPartialView", customer);
        }

    }
}
