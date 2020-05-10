using MERP_Character_Sheet_BE.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MERP_Character_Sheet_BE.Interfaces
{
    public interface ICharacterRepository
    {
        Task<bool> Create(Character _char);

        Task<bool> Update(Character _char);

        Character Get(int charId);

        IOrderedQueryable<Character> GetAll();

        Task<bool> Delete(int charId);
    }
}
