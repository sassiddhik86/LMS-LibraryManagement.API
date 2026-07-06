using LibraryManagement.API.DTO.Books;

namespace LibraryManagement.API.Services;

public interface IBookService
{
    Task<IEnumerable<BookResponse>> GetAllAsync();
    Task<BookResponse?> GetByIdAsync(int id);
    Task<BookResponse> CreateAsync(CreateBookRequest request);
    Task<ServiceResult<BookResponse>> UpdateAsync(int id, UpdateBookRequest request);
    Task<ServiceResult<bool>> DeleteAsync(int id);
}
