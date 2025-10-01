using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Application.DTOs.User
{
    public record UserResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserType { get; set; }
        public UserResponseDTO(int id, string name, string email, DateTime createdat, int usertype )
        {
            Id = id;
            Name = name;
            Email = email;
            CreatedAt = createdat;
            UserType = usertype;
        }

    }
}
