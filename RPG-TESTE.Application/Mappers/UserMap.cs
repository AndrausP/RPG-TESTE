using RPG_TESTE.Application.DTOs.User;
using RPG_TESTE.Domain.Entity;
using RPG_TESTE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Application.Mappers
{
    public static class UserMap
    {
        public static User ToEntity(this UserCreateDTO dto, byte[] hash, byte[] salt)
        {
            return new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = hash,
                PasswordSalt = salt,
                UserType = (UserEnum)dto.UserType
            };
        }
        public static UserResponseDTO ToUserResponseDto(this User entity)
        {
            return new UserResponseDTO(entity.Id, entity.Name, entity.Email, entity.CreatedAt,(int)entity.UserType);
        }
    }
}
