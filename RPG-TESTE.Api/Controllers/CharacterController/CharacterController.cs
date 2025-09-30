using Microsoft.AspNetCore.Mvc;
using RPG_TESTE.Application.DTOs.Character;

namespace RPG_TESTE.Api.Controllers.CharacterController
{
    public class CharacterController : Controller
    {
       public async Task<ActionResult<CharacterResponseDTO>> CreateCharacterControll([FromBody] CharacterCreateDTO)
        {
            return Ok();
        }   
    }
}
