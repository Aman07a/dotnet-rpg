using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character { Id = 1, Name = "Sam" }
        };

        public async Task<ServiceReponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            var serviceReponse = new ServiceReponse<List<GetCharacterDTO>>();
            characters.Add(newCharacter);
            serviceReponse.Data = characters;
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            var serviceReponse = new ServiceReponse<List<Character>>();
            serviceReponse.Data = characters;
            return serviceReponse;
        }

        public async Task<ServiceReponse<GetCharacterDTO>> GetCharacterById(int id)
        {
            var serviceReponse = new ServiceReponse<Character>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceReponse.Data = character;
            return serviceReponse;
        }
    }
}