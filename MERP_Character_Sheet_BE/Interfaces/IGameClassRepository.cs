using MERP_Character_Sheet_BE.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MERP_Character_Sheet_BE.Interfaces
{
    public interface IGameClassRepository
    {
        Task<bool> Create(GameClass _class);

        Task<bool> Update(GameClass _class);

        GameClass Get(long classId);

        IOrderedQueryable<GameClass> GetAll();

        Task<bool> Delete(long classId);
    }
}
