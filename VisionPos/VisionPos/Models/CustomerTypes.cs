using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisionPos.Models
{
    public class CustomerTypes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string CustomerType { get; set; }

        [Required]
        [DisplayName("Date")]
        public DateTime CreationDate { get; set; }
    }
}
