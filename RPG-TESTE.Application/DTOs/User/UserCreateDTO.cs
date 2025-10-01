using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Application.DTOs.User
{
    public record UserCreateDTO
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public int UserType { get; init; }

        public UserCreateDTO(string name, string email, string password, int userType)
        {
            Name = name;
            Email = email;
            Password = password;
            UserType = userType;
        }
    }
}
