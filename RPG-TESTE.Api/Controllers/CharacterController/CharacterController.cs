using Microsoft.AspNetCore.Mvc;
using RPG_TESTE.Application.DTOs;
using RPG_TESTE.Application.Interfaces.CharacterInterfaces;
using RPG_TESTE.Domain.Enums;
using RPG_TESTE.Domain.UnifiedResponse;

namespace RPG_TESTE.Api.Controllers.CharacterController
{
    public class CharacterController(ICharacterQueryService characterQueryService, ICharacterService characterService) : Controller
    {
        [HttpPost("CreateCharacter")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CharacterResponseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Result<CharacterResponseDTO>> CreateCharacterControll([FromBody] CharacterCreateDTO characterCreateDTO)
        {
            var result = await characterService.CreateCharacterAsync(characterCreateDTO);
            return result;

        }
        [HttpGet("GetAllCharacters")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CharacterResponseDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CharacterResponseDTO>>> GetAllCharacterControll()
        {
            var list = await characterQueryService.GetAllCharactersAsync();
            return Ok(list);
        }
        [HttpGet("DeleteCharacterById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CharacterResponseDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var chaDelete = await characterService.DeleteCharacterAsync(id);
            if (chaDelete is null)
                return Result<bool>.Failure("Character not found.", 404);
            return Result<object>.Success(new { deleted = true, message = "Character deleted successfully." },
                                            StatusCodes.Status200OK);
        }
        [HttpPut("UpdateCharacterById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CharacterUpdateDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCharacter(int id, [FromBody] CharacterUpdateDTO characterUpdateDTO)
        {
            var chaUpdate = await characterService.UpdateCharacterAsync(id, characterUpdateDTO);
            if (chaUpdate is null)
                return Result<CharacterUpdateDTO>.Failure("Character not found.", 404);
            return Result<CharacterUpdateDTO>.Success(chaUpdate.Data, StatusCodes.Status200OK);
        }
        [HttpGet("GetCharacterClassByEnumIntOrName")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CharacterResponseDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CharacterResponseDTO>>> GetCharacterClass(RpgClass rpgClass)
        {
            var list = await characterQueryService.GetAllClasses(rpgClass);
            return Ok(list);
        }
    }
}
