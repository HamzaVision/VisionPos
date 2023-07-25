using Microsoft.AspNetCore.Mvc;
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
                SalesInvoiceItems = _db.tbSalesInvoiceItems.Include(x => x.TbSalesInvoice).Include(x => x.TbItems).ToList()
            };


            return View(mod);
        }
    }
}
