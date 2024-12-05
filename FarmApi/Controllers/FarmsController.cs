using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmApi.Models;

namespace FarmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmsController : ControllerBase
    {
        private readonly FarmContext _context;

        public FarmsController(FarmContext context)
        {
            _context = context;
        }

        [HttpGet("FindGrower")]
        public IActionResult FindGrower(string searchTarget) { 

            var growers = _context.Growers.Where(grower=> grower.GrowerName.Contains(searchTarget)).ToList();

            if (growers == null)
                return NotFound();

            return Ok(growers);
        
        }

        [HttpGet("GetFields")] 
        
        public IActionResult GetFields(Guid growerID)
        {
            var grower = _context.Growers.Include(g => g.Fields).FirstOrDefault(g => g.GrowerID == growerID);

            if (grower == null)
                return NotFound();

            return Ok(grower.Fields);
        }
      
    }
}
