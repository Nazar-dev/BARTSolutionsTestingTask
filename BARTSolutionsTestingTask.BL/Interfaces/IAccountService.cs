using System.Collections.Generic;
using System.Threading.Tasks;
using BARTSolutionsTestingTask.BL.Models;
using BARTSolutionsTestingTask.BL.Services;
using BARTSolutionsTestingTask.DAL.Entity;

namespace BARTSolutionsTestingTask.BL.Interfaces {
	public interface IAccountService:IService<AccountModel> {
		Task<AccountModel> GetBy(string name);
		Task<AccountModel> GetByEmail(string email);
		Task<IEnumerable<ContactModel>> GetContactsByName(string name);

		Task LinkContact(string name, ContactModel contactModel);


	}
}