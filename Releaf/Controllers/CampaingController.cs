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
	public class CampaingController : ControllerBase
	{
		private readonly IBaseRepository<Campaing> _campaignRepository;

		public CampaingController(IBaseRepository<Campaing> campaignRepository)
		{
			_campaignRepository = campaignRepository;
		}

		[HttpGet("GetById/{id:int}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var campaign = await _campaignRepository.GetByIdAsync(id);
			if (campaign == null)
				return NotFound("Campaign not found");

			return Ok(campaign);
		}

		[HttpGet("GetAllCampaigns")]
		public async Task<IActionResult> GetAllCampaignsAsync()
		{
			var campaigns = await _campaignRepository.GetAllAsync();
			return Ok(campaigns);
		}

		[HttpPost("AddCampaign")]
		public async Task<IActionResult> AddCampaignAsync([FromBody] Campaing campaign)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var createdCampaign = await _campaignRepository.AddAsync(campaign);
			return CreatedAtAction(nameof(GetByIdAsync), new { id = createdCampaign.Id }, createdCampaign);
		}

		[HttpPut("UpdateCampaign/{id:int}")]
		public async Task<IActionResult> UpdateCampaignAsync(int id, [FromBody] Campaing campaignFromRequest)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var exists = await _campaignRepository.ExistsAsync(id);
			if (!exists)
				return NotFound("Campaign not found");

			campaignFromRequest.Id = id;   
			var updatedCampaign = await _campaignRepository.UpdateAsync(campaignFromRequest);

			return Ok(updatedCampaign);
		}

		[HttpDelete("DeleteCampaign/{id:int}")]
		public async Task<IActionResult> DeleteCampaignAsync(int id)
		{
			var exists = await _campaignRepository.ExistsAsync(id);
			if (!exists)
				return NotFound("Campaign not found");

			var deleted = await _campaignRepository.DeleteByIdAsync(id);
			if (!deleted)
				return BadRequest("Failed to delete campaign");

			return Ok("Deleted successfully");
		}
	}
}
