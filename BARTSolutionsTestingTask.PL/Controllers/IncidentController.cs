using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BARTSolutionsTestingTask.BL.Interfaces;
using BARTSolutionsTestingTask.BL.Models;
using BARTSolutionsTestingTask.DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BARTSolutionsTestingTask.Controllers {
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class IncidentController:ControllerBase {
		private readonly IIncidentService _incidentService;
		public IncidentController(IIncidentService incidentService) {
			_incidentService = incidentService;
		}
		[HttpGet]
		public async Task<IEnumerable<IncidentModel>> GetAllAccounts()
		{
            
			try
			{
				return await _incidentService.GetAllAsync();
			}
			catch (Exception e)
			{
				return null;
			}
		}
		[HttpPost]
		public async Task<IActionResult> CreateIncident([FromBody]IncidentModel incidentModel)
		{
			if (incidentModel == null)
			{
				return BadRequest();
			}

			try
			{
				await _incidentService.AddAsync(incidentModel);
				return new JsonResult("Added Successfully");
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}