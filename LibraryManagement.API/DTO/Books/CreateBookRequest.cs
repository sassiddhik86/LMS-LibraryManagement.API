using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.API.DTO.Books;

public class CreateBookRequest
{
    [Required]
    [StringLength(200)]
    public required string Title { get; set; }

    [Required]
    [StringLength(100)]
    public required string Author { get; set; }

    [Required]
    [StringLength(20)]
    public required string ISBN { get; set; }

    [Range(1, 9999)]
    public int PublicationYear { get; set; }

    [StringLength(100)]
    public string? Category { get; set; }

    public int TotalCopies { get; set; }

    public int AvailableCopies { get; set; }
}
