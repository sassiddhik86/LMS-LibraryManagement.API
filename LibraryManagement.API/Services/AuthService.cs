using LibraryManagement.API.Data;
using LibraryManagement.API.DTO.Auth;
using LibraryManagement.API.Models;
using LibraryManagemet.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryManagement.API.Services;

public class AuthService : IAuthService
{
    private readonly LibraryDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly JwtService _jwtService;

    public AuthService(LibraryDbContext context, IConfiguration configuration, JwtService jwt)
    {
        _context = context;
        _configuration = configuration;
        _jwtService = jwt;
    }

    public async Task<ServiceResult<AuthResponse>> RegisterAsync(RegisterRequest request)
    {
        var emailExists = await _context.Users.AnyAsync(u => u.Email == request.Email);
        if (emailExists)
            return ServiceResult<AuthResponse>.Fail("Email is already registered.", ServiceErrorType.Conflict);

        var user = new User
        {
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = request.Role,
            CreatedAt = DateTime.UtcNow
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return ServiceResult<AuthResponse>.Ok(_jwtService.GenerateToken(user));
    }

    public async Task<ServiceResult<AuthResponse>> LoginAsync(LoginRequest request)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == request.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return ServiceResult<AuthResponse>.Fail("Invalid email or password.", ServiceErrorType.Validation);

        return ServiceResult<AuthResponse>.Ok(_jwtService.GenerateToken(user));
    }
}
