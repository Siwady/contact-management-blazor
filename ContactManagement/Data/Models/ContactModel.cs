using System.ComponentModel.DataAnnotations;
namespace ContactManagement.Data.Models
{
    public class ContactModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
