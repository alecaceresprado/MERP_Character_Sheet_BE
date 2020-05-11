using MERP_Character_Sheet_BE.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MERP_Character_Sheet_BE
{
    public interface IGameClassService
    {
        Task<GameClass> Create(GameClass _class);

        Task<GameClass> Update(GameClass _class);

        GameClass Get(long classId);

        IOrderedQueryable<GameClass> GetAll();

        Task<bool> Delete(long classId);
    }
}
