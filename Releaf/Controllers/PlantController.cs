using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Releaf.Core.Models;
using Releaf.EF;


namespace Releaf.API.Controllers
{
	//[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class PlantController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _env;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public PlantController(ApplicationDbContext context, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
		{
			_context = context;
			_env = env;
			_httpContextAccessor = httpContextAccessor;
			
		}

		[HttpGet("GetAllPlants")]
		public async Task<ActionResult<IEnumerable<Plant>>> GetPlants()
		{
			return await _context.Plants.ToListAsync();
		}


		[HttpGet("GetByID/{id}")]
		public async Task<ActionResult<Plant>> GetById(int id)
		{
			var plant = await _context.Set<Plant>().FindAsync(id);

			if (plant == null)
			{
				return NotFound();
			}

			return plant;
		}

		[HttpGet("GetAllPlantsByCategoryId/{categoryId}")]
		public async Task<ActionResult<IEnumerable<Plant>>> GetAllPlantsByCategoryId(int categoryId)
		{
			var plants = await _context.Set<Plant>()
				.Where(p => p.CategoryId == categoryId)
				.ToListAsync();

			if (!plants.Any())
			{
				return NotFound();
			}

			return Ok(plants);
		}



		






	}
}
