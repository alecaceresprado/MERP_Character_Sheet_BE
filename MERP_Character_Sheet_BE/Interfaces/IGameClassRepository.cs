using MERP_Character_Sheet_BE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MERP_Character_Sheet_BE.Interfaces
{
    public interface IGameClassRepository
    {
        Task<bool> Create(GameClass _class);

        Task<bool> Update(GameClass _class);

        GameClassDTO Get(long classId);

        GameClass GetWithIDs(long classId);

        List<GameClassDTO> GetAll();

        Task<bool> Delete(long classId);
    }
}
