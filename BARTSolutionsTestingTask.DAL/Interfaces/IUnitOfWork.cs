using System.Threading.Tasks;

namespace BARTSolutionsTestingTask.DAL.Interfaces {
	public interface IUnitOfWork {
		public IIncidentRepository IncidentRepository { get; }
		public IContactRepository ContactRepository { get; }
		public IAccountRepository AccountRepository { get; }
		public Task<int> SaveAsync();
	}
}