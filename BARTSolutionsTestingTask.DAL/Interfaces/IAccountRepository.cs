using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BARTSolutionsTestingTask.DAL.Entity;

namespace BARTSolutionsTestingTask.DAL.Interfaces {
	public interface IAccountRepository:IRepository<Account> {
		Task<Account> GetBy(string name);
		Task<Account> GetByEmail(string email);
		Task<IEnumerable<Contact>> GetContactsByName(string name);

		Task LinkContact(string name,Contact contact);
	}
}