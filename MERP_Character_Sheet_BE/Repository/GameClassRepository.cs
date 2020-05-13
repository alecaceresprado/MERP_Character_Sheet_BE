using MERP_Character_Sheet_BE.Interfaces;
using MERP_Character_Sheet_BE.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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

            var existingClass = GetWithIDs(_class.Id);

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

        public GameClassDTO Get(long classId)
        {
            var result = _dbContext.Classes
                                .Where(x => x.Id == classId)
                                .FirstOrDefault();
            if(result == null)
            {
                return null;
            }
            return (GameClassDTO)result;
        }

        public GameClass GetWithIDs(long classId)
        {
            return _dbContext.Classes
                                .Where(x => x.Id == classId)
                                .FirstOrDefault();
        }

        public List<GameClassDTO> GetAll()
        {
            var parsedList = new List<GameClassDTO>();
            var unparsed = _dbContext.Classes.OrderByDescending(x => x.Id).ToList();
            
            unparsed.ForEach(delegate(GameClass raw){
                parsedList.Add((GameClassDTO)raw);
            });
            
            return parsedList;
        }

        public async Task<bool> Delete(long classId)
        {
            var success = false;

            var existingClass = GetWithIDs(classId);

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
