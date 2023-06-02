using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BooKingSystemForntEnd.Models
{
    public class addGustcs
    {
        public string F_name { get; set; }
        [Required]
        public string L_name { get; set; }
        [Required]
        [EmailAddress]
        public string Emial { get; set; }
        [Column(TypeName = "Char"), MaxLength(11), MinLength(11)]
        public string PhoneNumber { get; set; }
    }
}
