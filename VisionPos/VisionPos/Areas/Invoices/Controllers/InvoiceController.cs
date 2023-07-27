using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VisionPos.Data;
using VisionPos.Models.ViewModels;

namespace VisionPos.Areas.Invoices.Controllers
{
    [Area("Invoices")]
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _db;
        public InvoiceController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            SalesInvoiceSalesItemsViewModel mod = new SalesInvoiceSalesItemsViewModel()
            {
                SalesInvoice = _db.tbSalesInvoice.Include(x => x.Customer).ToList(),
                SalesInvoiceItems = _db.tbSalesInvoiceItems.Include(x => x.TbSalesInvoice).Include(x => x.TbItems).ToList(),
                SaleInvoice = new Models.tbSalesInvoice(),
                SaleInvoiceItems = new Models.tbSalesInvoiceItems(),
                CustomerList = _db.Customers.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList(),
                ItemsList = _db.tbItems.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList(),
                myCount = 0
            };
            mod.CustomerList.Insert(0, new SelectListItem
            {
                Text = "Please Select",
                Value = "0"
            });
            mod.ItemsList.Insert(0, new SelectListItem
            {
                Text = "Please Select",
                Value = "0"
            });
            return View(mod);
        }
        public IActionResult Create()
        {
            SalesInvoiceSalesItemsViewModel mod = new SalesInvoiceSalesItemsViewModel()
            {
                SalesInvoice = _db.tbSalesInvoice.Include(x => x.Customer).ToList(),
                SalesInvoiceItems = _db.tbSalesInvoiceItems.Include(x => x.TbSalesInvoice).Include(x => x.TbItems).ToList(),
                SaleInvoice = new Models.tbSalesInvoice(),
                SaleInvoiceItems = new Models.tbSalesInvoiceItems(),
                CustomerList = _db.Customers.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList(),
                ItemsList = _db.tbItems.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList(),
                myCount = 1
            };
            mod.CustomerList.Insert(0, new SelectListItem
            {
                Text = "Please Select",
                Value = "0"
            });
            mod.ItemsList.Insert(0, new SelectListItem
            {
                Text = "Please Select",
                Value = "0"
            });
            return View("CreateAndEdit", mod);
        }

        public IActionResult Edit(int id)
        {
            var cus = _db.CustomerTypes.FirstOrDefault(x => x.Id == id);
            return View("CreateAndEdit", cus);
        }

        public IActionResult DisplayNewInvoiceItem(int id)
        {
            SalesInvoiceSalesItemsViewModel mod = new SalesInvoiceSalesItemsViewModel()
            {
                SalesInvoice = _db.tbSalesInvoice.Include(x => x.Customer).ToList(),
                SalesInvoiceItems = _db.tbSalesInvoiceItems.Include(x => x.TbSalesInvoice).Include(x => x.TbItems).ToList(),
                SaleInvoice = new Models.tbSalesInvoice(),
                SaleInvoiceItems = new Models.tbSalesInvoiceItems(),
                CustomerList = _db.Customers.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList(),
                ItemsList = _db.tbItems.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList(),
                myCount = id
            };
            mod.CustomerList.Insert(0, new SelectListItem
            {
                Text = "Please Select",
                Value = "0"
            });
            mod.ItemsList.Insert(0, new SelectListItem
            {
                Text = "Please Select",
                Value = "0"
            });
            return PartialView("_SalesInvoiceItemPartialView", mod);
        }
        [HttpGet]
        public IActionResult DisplayRate(int id)
        {
            if (id == 0)
            {
                return Json(null);
            }
            decimal cus = _db.tbItems.FirstOrDefault(x => x.Id == id).SalesRate;
            return Json(cus);
        }

    }
}
