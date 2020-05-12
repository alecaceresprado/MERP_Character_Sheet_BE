using MERP_Character_Sheet_BE.Interfaces;
using MERP_Character_Sheet_BE.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MERP_Character_Sheet_BE.Services
{
    public class CharactersService : ICharacterService
    {
        private readonly ICharacterRepository _repository;
        public CharactersService(ICharacterRepository repository)
        {
            _repository = repository;
        }
        public async Task<Character> Create(Character _char)
        {
            var success = await _repository.Create(_char);

            if (success)
                return _char;
            else
                return null;
        }

        public async Task<Character> Update(Character _char)
        {
            var success = await _repository.Update(_char);

            if (success)
                return _char;
            else
                return null;
        }

        public Character Get(int charId)
        {
            return _repository.Get(charId);
        }

        public IOrderedQueryable<Character> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<bool> Delete(int charId)
        {
            return await _repository.Delete(charId);
        }

    }
}
