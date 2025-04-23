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
	public class CategoryController : ControllerBase
	{
		private readonly IBaseRepository<Category> _categoryRepository;

		public CategoryController(IBaseRepository<Category> categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		[HttpGet("GetById/{id:int}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var category = await _categoryRepository.GetByIdAsync(id);
			if (category == null)
				return NotFound("Category not found");

			return Ok(category);
		}

		[HttpGet("GetAllCategories")]
		public async Task<IActionResult> GetAllCategoriesAsync()
		{
			var categories = await _categoryRepository.GetAllAsync();
			return Ok(categories);
		}

	}
}
