using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BARTSolutionsTestingTask.DAL.Entity;
using BARTSolutionsTestingTask.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BARTSolutionsTestingTask.DAL.Repository {
	public class AccountRepository:IAccountRepository {
		private readonly ApplicationDbContext _context;
		public AccountRepository(ApplicationDbContext context) {
			_context = context;
		}

		public async Task<IEnumerable<Account>> GetAllAsync() {
			return _context.Accounts;
		}
		public async Task Create(Account item) {
			await _context.Accounts.AddAsync(item);
		}
		public async Task<Account> GetBy(string name) {
			return await _context.Accounts.FirstOrDefaultAsync(account => account.Name == name);
		}
		public async Task<Account> GetByEmail(string email) {
			return await _context.Accounts.FirstOrDefaultAsync(account => account.Contacts.FirstOrDefault(x => x.Email == email) != null);
		}
		public async Task<IEnumerable<Contact>> GetContactsByName(string name) {
			return _context.Accounts.FirstOrDefaultAsync(account => account.Name == name).Result.Contacts;
		}
		public async Task LinkContact(string name, Contact contact) {
			Account result = await _context.Accounts.FirstOrDefaultAsync(account => account.Name == name);
			result.Contacts = result.Contacts.Append(contact);
		}


	}
}