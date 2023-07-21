using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisionPos.Models
{
    public class tbSalesInvoiceItems
    {

        [Key]
        public int Id { get; set; }

        [DisplayName("SaleInvoice Id")]
        public int SalesInvoiceId { get; set; }

        [ForeignKey("SalesInvoiceId")]
        public virtual tbSalesInvoice TbSalesInvoice { get; set; }

        [DisplayName("Item Id")]
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public virtual tbItems TbItems { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999999999999999.99)]
        [DisplayName("Rate")]
        public decimal Rate { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999999999999999.99)]
        [DisplayName("Quantity")]
        public decimal Quantity { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999999999999999.99)]
        [DisplayName("Discount")]
        public decimal Discount { get; set; }


        [Required]
        public DateTime CreationDate { get; set; }
    }
}
