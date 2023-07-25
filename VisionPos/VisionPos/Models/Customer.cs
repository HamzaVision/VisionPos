using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisionPos.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string Address { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [DisplayName("Type")]
        public int CustomerType { get; set; }

        [ForeignKey("CustomerType")]
        public virtual CustomerTypes CustomerTypes { get; set; }

        [Required]
        [DisplayName("Active")]
        public Boolean IsActive { get; set; }

        [Required]
        [DisplayName("Date")]
        public DateTime CreationDate { get; set; }
    }
}
