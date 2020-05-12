using MERP_Character_Sheet_BE.Interfaces;
using MERP_Character_Sheet_BE.Models;
using System.Linq;
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

        public GameClass Get(long classId)
        {
            return _repository.Get(classId);
        }

        public IOrderedQueryable<GameClass> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<bool> Delete(long classId)
        {
            return await _repository.Delete(classId);
        }

    }
}
