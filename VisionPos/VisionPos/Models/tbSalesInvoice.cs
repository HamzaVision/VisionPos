using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisionPos.Models
{
    public class tbSalesInvoice
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date")]
        public DateTime InvoiceDate { get; set; }


        [DisplayName("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string? Description { get; set; }


        [Required]
        //[RegularExpression(@"^\d+(\.\d{1,2})?$")]
        //[Range(0, 9999999999999999.99)]
        [DisplayName("Line Total")]
        public decimal LineTotal { get; set; }



        //[RegularExpression(@"^\d+(\.\d{1,2})?$")]
        //[Range(0, 9999999999999999.99)]
        [DisplayName("Discount")]
        public decimal? Discount { get; set; }


        [Required]
        //[RegularExpression(@"^\d+(\.\d{1,2})?$")]
        //[Range(0, 9999999999999999.99)]
        [DisplayName("Total Invoice")]
        public decimal InvoiceTotal { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
