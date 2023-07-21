using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisionPos.Models
{
    public class tbItems
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999999999999999.99)]
        [DisplayName("Sale Rate")]
        public decimal SalesRate { get; set; }

        [Required]
        public Boolean Active { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

    }
}
