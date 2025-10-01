using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Application.DTOs.User
{
    public record AuthResponseDTO(UserData User, string AccessToken);
}
