using LibraryManagemet.API.Models;

namespace LibraryManagement.API.Models;

public class Loan
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    public int MemberId { get; set; }
    public Member Member { get; set; } = null!;
    public DateTime BorrowedDate { get; set; }
    public DateTime? ReturnedDate { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsReturned { get; set; }
    public LoanStatus Status { get; set; }
}
