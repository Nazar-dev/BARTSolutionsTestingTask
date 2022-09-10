using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BARTSolutionsTestingTask.BL.Interfaces;
using BARTSolutionsTestingTask.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BARTSolutionsTestingTask.Controllers {
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController:ControllerBase {
		private readonly IContactService _contactService;
		public ContactController(IContactService contactService) {
			_contactService = contactService;
		}
		
		[HttpGet]
		public async Task<IEnumerable<ContactModel>> GetAll()
		{
            
			try
			{
				return await _contactService.GetAllAsync();
			}
			catch (Exception e)
			{
				return null;
			}
		}
		[HttpGet("{email}")]
		public async Task<ContactModel> GetByEmail(string email)
		{
			try
			{
				return await _contactService.GetBy(email);
			}
			catch (Exception e)
			{
				return null;
			}
		}
		[HttpPut]
		public async Task<IActionResult> UpdateContact([FromBody]ContactModel model)
		{
			if (model == null)
			{
				return BadRequest();
			}
        
			try
			{
				await _contactService.Update(model);
				return new JsonResult("Updated Successfully");
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		[HttpPost]
		public async Task<IActionResult> CreateContact([FromBody]ContactModel contactModel)
		{
			if (contactModel == null)
			{
				return BadRequest();
			}

			try
			{
				await _contactService.AddAsync(contactModel);
				return new JsonResult("Added Successfully");
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}