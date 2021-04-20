using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChoreChartAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChoreChartController : ControllerBase
    {
        private static readonly string[] Days = new[]
        {
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
        };

        private readonly ILogger<ChoreChartController> _logger;

        private static Random random = new Random();

        public ChoreChartController(ILogger<ChoreChartController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Chore> GetAllChores()
        {
            var random = new Random();
            return new List<Chore>
            {
                new Chore
                {
                    Id = random.Next(999999),
                    Name = "",
                    Instructions = "",
                    Value = random.Next(5),
                    Days = Days.Select(day => new Day
                    {
                        Name = day,
                        Status = "unchecked"
                    }).ToArray()
                }
            }
            .ToArray();
        }

        [HttpGet]
        public Chore GetChore()
        {
            return new Chore
            {
                Id = random.Next(999999),
                Name = "",
                Instructions = "",
                Value = random.Next(5),
                Days = Days.Select(day => new Day
                {
                    Name = day,
                    Status = "unchecked"
                }).ToArray()
            };
        }

        [HttpPost]
        public void SaveChore(Chore chore)
        {
            //save chore
        }

        [HttpDelete]
        public void DeleteChore(int id)
        {
            //delete chore
        }

        [HttpDelete]
        public void UpdateTotal(int amount)
        {
            //update total
        }
    }
}
