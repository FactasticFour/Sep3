using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class ViaEntity
    {
        [Required]
        [Range(0, 9999999, ErrorMessage = "The VIA ID should not be longer than 7 digits")]
        public int ViaId { get; set; }
        
        [Required]
        [MinLength(8, ErrorMessage = "VIA password is too short")]
        public string Password { get; set; }
    }
}