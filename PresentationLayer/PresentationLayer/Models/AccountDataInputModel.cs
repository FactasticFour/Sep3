using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class AccountDataInputModel
    {
        [Required]
        public string RoleType { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "App password is too short")]
        public string ApplicationPassword { get; set; }
    }
}