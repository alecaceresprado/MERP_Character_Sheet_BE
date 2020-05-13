using MERP_Character_Sheet_BE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MERP_Character_Sheet_BE
{
    public interface IGameClassService
    {
        Task<GameClass> Create(GameClass _class);

        Task<GameClass> Update(GameClass _class);

        GameClassDTO Get(long classId);

        List<GameClassDTO> GetAll();

        Task<bool> Delete(long classId);
    }
}
