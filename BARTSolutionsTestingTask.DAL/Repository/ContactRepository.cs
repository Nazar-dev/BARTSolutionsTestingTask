using System.Collections.Generic;
using System.Threading.Tasks;
using BARTSolutionsTestingTask.DAL.Entity;
using BARTSolutionsTestingTask.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BARTSolutionsTestingTask.DAL.Repository {
	public class ContactRepository:IContactRepository {
		private readonly ApplicationDbContext _context;
		public ContactRepository(ApplicationDbContext context) {
			_context = context;
		}

		public async Task<IEnumerable<Contact>> GetAllAsync() {
			return _context.Contacts;
		}
		public async Task Create(Contact item) {
			await _context.AddAsync(item);
		}
		public async Task<Contact> GetBy(string email) {
			return await _context.Contacts.FirstOrDefaultAsync(contact => contact.Email == email);
		}
		public void Update(Contact contact) {
			_context.Contacts.Update(contact);
		}

	}
}