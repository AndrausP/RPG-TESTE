using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Application.DTOs.User
{
    public record UserLoginDTO
    {
        public string Email { get; init; }
        public string Password { get; init; }
        public UserLoginDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
