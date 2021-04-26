using System.ComponentModel.DataAnnotations;

namespace Persistence.Model
{
    public class User
    {
        [Key] public int IdUser { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Password { get; set; }
        
    }
}