using System.Threading.Tasks;
using BARTSolutionsTestingTask.BL.Models;
using BARTSolutionsTestingTask.BL.Services;
using BARTSolutionsTestingTask.DAL.Entity;

namespace BARTSolutionsTestingTask.BL.Interfaces {
	public interface IContactService:IService<ContactModel> {
		Task<ContactModel> GetBy(string email);
		Task<int> Update(ContactModel contactModel);
	}
}