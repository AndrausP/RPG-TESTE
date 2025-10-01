using Microsoft.IdentityModel.JsonWebTokens;
using RPG_TESTE.Application.DTOs.User;
using RPG_TESTE.Application.Mappers;
using RPG_TESTE.Domain.Entity;
using RPG_TESTE.Domain.Interfaces;
using RPG_TESTE.Domain.Security;
using RPG_TESTE.Domain.UnifiedResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Application.Services.UserService
{
     
   public class UserService(IUserRepository userRepository, FluentValidation.IValidator<UserCreateDTO> validator, IJwtTokenGeneration jwtTokenGeneration) : IAuthService
    {
        public async Task<Result<UserResponseDTO>> CreateUser(UserCreateDTO dto)
        {
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                var errorMessages = string.Join("; ", validationResult.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));
                return Result<UserResponseDTO>.Failure(new Error(errorMessages));
            }
            var (hash, salt) = PasswordHash(dto.Password);
            var user = dto.ToEntity(hash, salt);
            var userCreated = await userRepository.CreateUserAsync(user);
            if (userCreated == null)
                return Result<UserResponseDTO>.Failure(new Error("Failed to create user."));
            var responseDto = userCreated.ToUserResponseDto();
            return Result<UserResponseDTO>.Success(responseDto);
        }
        public async Task<Result<AuthResponseDTO>> LoginAsync(UserLoginDTO dto)
        {
            var user = await userRepository.ValidateEmail(dto.Email);
            if (user is null || !VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
                return Result<AuthResponseDTO>.Failure("Invalid email or password");
            var token = GenerateTokenForUser(user);
            return Result<AuthResponseDTO>.Success(new AuthResponseDTO(new UserData(user.Id, user.Name, user.Email, user.UserType.ToString()), token));
        }
        private string GenerateTokenForUser(User user)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email),
                 new Claim(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Role, user.UserType.ToString())
            };
            var token = jwtTokenGeneration.GenerateToken(claims);
            return token;
        }
        public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(
                password,
                storedSalt,
                100_000,
                System.Security.Cryptography.HashAlgorithmName.SHA256
            ))
            {
                var computedHash = pbkdf2.GetBytes(32);
                return computedHash.SequenceEqual(storedHash);
            }
        }
        public async Task<Result<bool>> DeleteUserAsync(int userId)
        {
            var deleteUserDefinite = await userRepository.DeleteUserAsync(userId);
            if (deleteUserDefinite is false)
                return Result<bool>.Failure("User not found.");
            return Result<bool>.Success(true);
        }
        public (byte[] hash, byte[] salt) PasswordHash(string password)
        {
            var salt = new byte[16];
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
                rng.GetBytes(salt);
            using (var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(password, salt, 100_000, System.Security.Cryptography.HashAlgorithmName.SHA256))
            {
                var hash = pbkdf2.GetBytes(32);
                return (hash, salt);
            }
        }
    }
}
