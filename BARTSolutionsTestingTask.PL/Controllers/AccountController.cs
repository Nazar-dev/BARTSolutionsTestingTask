using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BARTSolutionsTestingTask.BL.Interfaces;
using BARTSolutionsTestingTask.BL.Models;
using BARTSolutionsTestingTask.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BARTSolutionsTestingTask.Controllers {
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController:ControllerBase {
		private readonly IAccountService _accountService;
		public AccountController(IAccountService accountService) {
			_accountService = accountService;
		}
		
		
		[HttpGet]
		public async Task<IEnumerable<AccountModel>> GetAllAccounts()
		{
            
			try
			{
				return await _accountService.GetAllAsync();
			}
			catch (Exception e)
			{
				return null;
			}
		}
		[HttpGet("{email}")]
		public async Task<AccountModel> GetByEmail(string email)
		{
			try
			{
				return await _accountService.GetByEmail(email);
			}
			catch (Exception e)
			{
				return null;
			}
		}
		[HttpGet("{name}")]
		public async Task<AccountModel> GetByName(string name)
		{
			try
			{
				return await _accountService.GetBy(name);
			}
			catch (Exception e)
			{
				return null;
			}
		}
		[HttpGet("{name}")]
		public async Task<IEnumerable<ContactModel>> GetContactsByName(string name)
		{
			try
			{
				return await _accountService.GetContactsByName(name);
			}
			catch (Exception e)
			{
				return null;
			}
		}
		[HttpPost]
		public async Task<IActionResult> CreateAccount([FromBody]AccountModel accountModel)
		{
			if (accountModel == null)
			{
				return BadRequest();
			}

			try
			{
				await _accountService.AddAsync(accountModel);
				return new JsonResult("Added Successfully");
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

	}
	
}