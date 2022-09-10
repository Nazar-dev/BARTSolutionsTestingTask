using System;
using System.Threading.Tasks;
using BARTSolutionsTestingTask.BL.Interfaces;
using BARTSolutionsTestingTask.BL.Models;
using BARTSolutionsTestingTask.DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BARTSolutionsTestingTask.Controllers {
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase {
		private readonly IIncidentService _incidentService;
		private readonly IAccountService _accountService;
		private readonly IContactService _contactService;

		public TestController(IIncidentService incidentService, IAccountService accountService, IContactService contactService) {
			_incidentService = incidentService;
			_accountService = accountService;
			_contactService = contactService;
		}


		[HttpPost]
		public async Task<IActionResult> Create([FromBody] TaskModel model) {
			if (model == null) {
				return BadRequest();
			}
			if (_accountService.GetBy(model.AccountName) == null) {
				return NotFound();
			}
			if (_contactService.GetBy(model.ContactEmail) == null) {
				ContactModel contactModel = new ContactModel() {
					Email = model.ContactEmail,
					FirstName = model.ContactFirstName,
					LastName = model.ContactLastName
				};
				await _contactService.AddAsync(contactModel);
				await _accountService.LinkContact(model.AccountName, contactModel);
				IncidentModel incidentModel = new IncidentModel() {
					Description = model.Description, Name = "indcident -" + Guid.NewGuid(),
					AccountsId = new[] { _accountService.GetBy(model.AccountName).Result.AccountId }
				};

			} else {
				await _contactService.Update(new ContactModel() {
					Email = model.ContactEmail,
					FirstName = model.ContactFirstName,
					LastName = model.ContactLastName
				});
			}


			try {
				return new JsonResult("Added Successfully");
			}
			catch (Exception e) {
				return BadRequest(e.Message);
			}
		}

	}
}