using LibraryManagement.API.DTO.Loans;

namespace LibraryManagement.API.Services;

public interface ILoanService
{
    Task<IEnumerable<LoanResponse>> GetAllAsync();
    Task<IEnumerable<LoanResponse>> GetByMemberAsync(int memberId);
    Task<ServiceResult<LoanResponse>> BorrowBookAsync(CreateLoanRequest request);
    Task<ServiceResult<LoanResponse>> ReturnBookAsync(int loanId);
}
