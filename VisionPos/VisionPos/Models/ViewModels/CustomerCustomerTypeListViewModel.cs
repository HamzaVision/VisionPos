using Microsoft.AspNetCore.Mvc.Rendering;

namespace VisionPos.Models.ViewModels
{
    public class CustomerCustomerTypeListViewModel
    {
        public Customer Customer { get; set; }
        public List<SelectListItem> CustomersList { get; set; }
        //public List<SelectListItem> CustomersNameList { get; set; }
    }
}
