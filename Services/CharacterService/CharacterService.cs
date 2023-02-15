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

        public async Task<ServiceReponse<List<Character>>> AddCharacter(Character character)
        {
            var serviceReponse = new ServiceReponse<List<Character>>();
            characters.Add(character);
            serviceReponse.Data = characters;
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<Character>>> GetAllCharacters()
        {
            var serviceReponse = new ServiceReponse<List<Character>>();
            serviceReponse.Data = characters;
            return serviceReponse;
        }

        public async Task<ServiceReponse<Character>> GetCharacterById(int id)
        {
            var serviceReponse = new ServiceReponse<Character>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceReponse.Data = character;
            return serviceReponse;
        }
    }
}