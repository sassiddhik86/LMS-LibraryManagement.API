using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.API.DTO.Loans;

public class CreateLoanRequest
{
    [Required]
    public int BookId { get; set; }

    [Required]
    public int MemberId { get; set; }
}
