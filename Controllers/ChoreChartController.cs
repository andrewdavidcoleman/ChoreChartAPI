﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChoreChartAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoreChartController : ControllerBase
    {
        private static readonly string[] _days = new[]
        {
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
        };

        private readonly ILogger<ChoreChartController> _logger;

        private readonly ChoreChartContext _context;

        public ChoreChartController(ChoreChartContext context)
        {
            _context = context;
        }

        // GET: /ChoreChart
        [HttpGet]
        public  ActionResult<IEnumerable<Chore>> GetAllChores(int id)
        {
            var chores = _context.Chores;

            return chores;
        }

        // GET: /ChoreChart/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<Chore>> GetChore(int id)
        {
            var chore = await _context.Chores.FindAsync(id);

            if (chore == null)
            {
                return NotFound();
            }

            return chore;
        }

        // POST: /ChoreChart
        [HttpPost]
        public async Task<ActionResult<Chore>> CreateChore(Chore chore)
        {
            _context.Chores.Add(chore);
            _context.Days.AddRange(_days.Select(day => new Day() { 
                Name = day,
                ChoreId = chore.Id,
                Status = "unchecked"
            }));
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChore), new { id = chore.Id }, chore);
        }

        // PUT: /ChoreChart
        [HttpPut]
        public async Task<ActionResult<Chore>> UpdateChore(Chore chore)
        {
            _context.Chores.Update(chore);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChore), new { id = chore.Id }, chore);
        }

        // DELETE: /ChoreChart/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChore(int id)
        {
            var chore = await _context.Chores.FindAsync(id);
            if (chore == null)
            {
                return NotFound();
            }

            _context.Chores.Remove(chore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: /ChoreChart
        [HttpGet("days/{choreId}")]
        public ActionResult<IEnumerable<Day>> GetDays(int choreId)
        {
            var days = _context.Days.Where(d => d.ChoreId == choreId).ToArray();

            return days;
        }
    }
}
