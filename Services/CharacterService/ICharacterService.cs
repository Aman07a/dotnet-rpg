using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceReponse<List<Character>>> GetAllCharacters();
        Task<ServiceReponse<Character>> GetCharacterById(int id);
        Task<ServiceReponse<List<Character>>> AddCharacter(Character character);
    }
}