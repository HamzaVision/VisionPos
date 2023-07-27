using Microsoft.AspNetCore.Mvc.Rendering;

namespace VisionPos.Models.ViewModels
{
    public class SalesInvoiceSalesItemsViewModel
    {
        public List<tbSalesInvoice> SalesInvoice { get; set; }
        public List<tbSalesInvoiceItems> SalesInvoiceItems { get; set; }

        public tbSalesInvoice SaleInvoice { get; set; }
        public tbSalesInvoiceItems SaleInvoiceItems { get; set; }

        public List<SelectListItem> CustomerList { get; set; }
        public List<SelectListItem> ItemsList { get; set; }
        public int myCount { get; set; }
    }
}
