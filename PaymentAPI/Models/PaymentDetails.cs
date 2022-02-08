using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentAPI.Models
{
    public class PaymentDetails
    {
        [Key]
        public int PaymentDetailId { get; set; }

        [Column(TypeName = "varchar(128)")]
        [Required]
        public string CardOwnerName { get; set; }

        [Column(TypeName = "varchar(16)")]
        [Required(ErrorMessage = "Card number is required")]
        public string CardNumber { get; set; }

        [Column(TypeName = "varchar(8)")]
        public string ExpireDate { get; set; }
        public string SecurityCode { get; set; }
    }
}
