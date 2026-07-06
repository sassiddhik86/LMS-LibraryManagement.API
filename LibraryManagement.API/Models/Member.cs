using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.API.Models;

public class Member
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public required string FirstName { get; set; }
    [Required]
    [StringLength(100)]
    public required string LastName { get; set; }
    [Required]
    [StringLength(200)]
    [EmailAddress]
    public required string Email { get; set; }
    [StringLength(20)]
    public string? Phone { get; set; }
    public DateTime RegisteredDate { get; set; }
    public bool IsActive { get; set; }
}
