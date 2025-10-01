using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Domain.Security
{
    public interface IJwtTokenGeneration
    {
        public string GenerateToken(IEnumerable<Claim> claims);
    }
}
