using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceReponse<List<GetCharacterDTO>>> GetAllCharacters();
        Task<ServiceReponse<GetCharacterDTO>> GetCharacterById(int id);
        Task<ServiceReponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter);
        Task<ServiceReponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatedCharacter);
        Task<ServiceReponse<List<GetCharacterDTO>>> DeleteCharacter(int id);
    }
}