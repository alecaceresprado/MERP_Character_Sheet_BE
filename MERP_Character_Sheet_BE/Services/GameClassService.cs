using MERP_Character_Sheet_BE.Interfaces;
using MERP_Character_Sheet_BE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MERP_Character_Sheet_BE.Services
{
    public class GameClassService : IGameClassService
    {
        private readonly IGameClassRepository _repository;
        public GameClassService(IGameClassRepository repository)
        {
            _repository = repository;
        }
        public async Task<GameClass> Create(GameClass _class)
        {
            var success = await _repository.Create(_class);

            if (success)
                return _class;
            else
                return null;
        }

        public async Task<GameClass> Update(GameClass _class)
        {
            var success = await _repository.Update(_class);

            if (success)
                return _class;
            else
                return null;
        }

        public GameClassDTO Get(long classId)
        {
            return _repository.Get(classId);
        }

        public List<GameClassDTO> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<bool> Delete(long classId)
        {
            return await _repository.Delete(classId);
        }

    }
}
