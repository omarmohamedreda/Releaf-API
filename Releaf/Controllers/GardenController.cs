using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Releaf.Core.Interfaces;
using Releaf.Core.Models;


namespace Releaf.API.Controllers
{
	//[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class GardenController : ControllerBase
	{
		private readonly IBaseRepository<Garden> _gardenRepository;

		public GardenController(IBaseRepository<Garden> gardenRepository)
		{
			_gardenRepository = gardenRepository;
		}

		[HttpGet("GetById/{id:int}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var garden = await _gardenRepository.GetByIdAsync(id);
			if (garden == null)
				return NotFound("Garden not found");

			return Ok(garden);
		}

		[HttpGet("GetAllGardens")]
		public async Task<IActionResult> GetAllGardensAsync()
		{
			var gardens = await _gardenRepository.GetAllAsync();
			return Ok(gardens);
		}
	}
}
