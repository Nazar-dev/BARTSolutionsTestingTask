using System.Threading.Tasks;
using BARTSolutionsTestingTask.DAL.Entity;

namespace BARTSolutionsTestingTask.DAL.Interfaces {
	public interface IContactRepository:IRepository<Contact> {
		Task<Contact> GetBy(string email);
		void Update(Contact contact);
	}
}