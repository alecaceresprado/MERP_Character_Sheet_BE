using MERP_Character_Sheet_BE.Interfaces;
using MERP_Character_Sheet_BE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MERP_Character_Sheet_BE.Repository
{
    public class GameClassRepository : IGameClassRepository
    {
        private readonly IServiceScope _scope;
        private readonly GameClassContext _dbContext;

        public GameClassRepository(IServiceProvider services)
        {
            _scope = services.CreateScope();
            _dbContext = _scope.ServiceProvider.GetRequiredService<GameClassContext>();
        }

        public async Task<bool> Create(GameClass _class)
        {
            _dbContext.Classes.Add(_class);

            var numberOfItemsCreated = await _dbContext.SaveChangesAsync();

            if (numberOfItemsCreated == 0)
                return false;

            return true;
        }

        public async Task<bool> Update(GameClass _class)
        {
            var success = false;

            var existingClass = Get(_class.Id);

            if (existingClass != null)
            {
                // TODO: Add parser;

                _dbContext.Classes.Attach(existingClass);

                var numberOfItemsUpdated = await _dbContext.SaveChangesAsync();

                if (numberOfItemsUpdated == 1)
                    success = true;
            }

            return success;
        }

        public GameClass Get(long classId)
        {
            return _dbContext.Classes
                                .Where(x => x.Id == classId)
                                .FirstOrDefault();
        }

        public IOrderedQueryable<GameClass> GetAll()
        {
            return _dbContext.Classes.OrderByDescending(x => x.Id);
        }

        public async Task<bool> Delete(long classId)
        {
            var success = false;

            var existingClass = Get(classId);

            if (existingClass != null)
            {
                _dbContext.Classes.Remove(existingClass);

                var numberOfItemsDeleted = await _dbContext.SaveChangesAsync();

                if (numberOfItemsDeleted == 1)
                    success = true;
            }

            return success;
        }
    }
}
