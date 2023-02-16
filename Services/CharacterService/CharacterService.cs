global using AutoMapper;
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

        public readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceReponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            var serviceReponse = new ServiceReponse<List<GetCharacterDTO>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceReponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceReponse;
        }

        public async Task<ServiceReponse<GetCharacterDTO>> GetCharacterById(int id)
        {
            var serviceReponse = new ServiceReponse<GetCharacterDTO>();
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            serviceReponse.Data = _mapper.Map<GetCharacterDTO>(dbCharacter);
            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            var serviceReponse = new ServiceReponse<List<GetCharacterDTO>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            serviceReponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceReponse;
        }

        public async Task<ServiceReponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatedCharacter)
        {
            var serviceReponse = new ServiceReponse<GetCharacterDTO>();

            try
            {
                var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

                if (character is null)
                    throw new Exception($"Character with Id '{updatedCharacter.Id}' not found.");

                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strength = updatedCharacter.Strength;
                character.Defense = updatedCharacter.Defense;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;

                serviceReponse.Data = _mapper.Map<GetCharacterDTO>(character);
            }
            catch (Exception ex)
            {
                serviceReponse.Success = false;
                serviceReponse.Message = ex.Message;
            }

            return serviceReponse;
        }

        public async Task<ServiceReponse<List<GetCharacterDTO>>> DeleteCharacter(int id)
        {
            var serviceReponse = new ServiceReponse<List<GetCharacterDTO>>();

            try
            {
                var character = characters.FirstOrDefault(c => c.Id == id);

                if (character is null)
                    throw new Exception($"Character with Id '{id}' not found.");

                characters.Remove(character);

                serviceReponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceReponse.Success = false;
                serviceReponse.Message = ex.Message;
            }

            return serviceReponse;
        }
    }
}