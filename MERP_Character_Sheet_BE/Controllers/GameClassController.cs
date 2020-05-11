using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MERP_Character_Sheet_BE.Models;
using Newtonsoft.Json;

// TODO: USE DTO to avoid sending un necesary IDs 
namespace MERP_Character_Sheet_BE.Controllers
{
    [ApiController]
    [Route("api/class")]
    public class GameClassController : ControllerBase
    {
        private readonly IGameClassService _classService;

        public GameClassController(IGameClassService classService)
        {
            _classService = classService;
        }

        // GET: api/Class
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _classService.GetAll();

            return Ok(result);
        }

        // GET: api/Class/5
        [HttpGet("{id}")]
        public IActionResult GetClass(int id)
        {
            var result = _classService.Get(id);

            return Ok(result);
        }

        // PUT: api/Class/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutClass(long id, GameClass gameClass)
        {
            return NoContent();
        }

        // POST: api/Class
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> PostCharacter(GameClass gameClass)
        {
            var result = await _classService.Create(gameClass);

            return CreatedAtAction(
                nameof(GetClass),
                new { id = result.Id }, result);
        }

        // DELETE: api/Class/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacter(long id)
        {
            var result = await _classService.Delete(id);

            return Ok(result);
        }
    }
}
