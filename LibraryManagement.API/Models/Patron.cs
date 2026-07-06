using System.ComponentModel.DataAnnotations;

namespace LibraryManagemet.API.Models
{
    public class Patron
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public required string Email { get; set; }
        [Required]
        public required string PasswordHash { get; set; }
        [Required]
        [StringLength(50)]
        public required string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
