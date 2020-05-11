using MERP_Character_Sheet_BE.Interfaces;
using MERP_Character_Sheet_BE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MERP_Character_Sheet_BE.Repository
{
    public class CharacterRepository: ICharacterRepository
    {
        private readonly IServiceScope _scope;
        private readonly CharacterContext _dbContext;

        public CharacterRepository(IServiceProvider services)
        {
            _scope = services.CreateScope();
            _dbContext = _scope.ServiceProvider.GetRequiredService<CharacterContext>();
        }

        public async Task<bool> Create(Character _char)
        {
            _dbContext.Characters.Add(_char);

            var numberOfItemsCreated = await _dbContext.SaveChangesAsync();

            if (numberOfItemsCreated == 0)
                return false;

            return true;
        }

        public async Task<bool> Update(Character _char)
        {
            var success = false;

            var existingChar = Get(_char.Id);

            if (existingChar != null)
            {
                existingChar.Details.Name = _char.Details.Name;
                existingChar.Details.NickName = _char.Details.NickName;
                existingChar.Details.PhysicalSpecial = _char.Details.PhysicalSpecial;
                existingChar.Details.Weight = _char.Details.Weight;
                existingChar.Details.Level = _char.Details.Level;
                existingChar.Details.Height = _char.Details.Height;
                existingChar.Details.HairColor = _char.Details.HairColor;
                existingChar.Details.EyesColor = _char.Details.EyesColor;
                existingChar.Details.Experience = _char.Details.Experience;

                _dbContext.Characters.Attach(existingChar);

                var numberOfItemsUpdated = await _dbContext.SaveChangesAsync();

                if (numberOfItemsUpdated == 1)
                    success = true;
            }

            return success;
        }

        public Character Get(int charId)
        {
            return _dbContext.Characters
                                .Where(x => x.Id == charId)
                                .FirstOrDefault();
        }

        public IOrderedQueryable<Character> GetAll()
        {
            return _dbContext.Characters.OrderByDescending(x => x.Id);
        }

        public async Task<bool> Delete(int charId)
        {
            var success = false;

            var existingChar = Get(charId);

            if (existingChar != null)
            {
                _dbContext.Characters.Remove(existingChar);

                var numberOfItemsDeleted = await _dbContext.SaveChangesAsync();

                if (numberOfItemsDeleted == 1)
                    success = true;
            }

            return success;
        }
    }
}
