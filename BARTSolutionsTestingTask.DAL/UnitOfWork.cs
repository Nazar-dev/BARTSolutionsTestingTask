using System.Threading.Tasks;
using BARTSolutionsTestingTask.DAL.Interfaces;
using BARTSolutionsTestingTask.DAL.Repository;

namespace BARTSolutionsTestingTask.DAL {
	public class UnitOfWork : IUnitOfWork {
		private readonly ApplicationDbContext _context;

		private IIncidentRepository _incidentRepository;

		private IContactRepository _contactRepository;

		private IAccountRepository _accountRepository;


		public UnitOfWork(ApplicationDbContext context) {
			_context = context;
		}

		public IIncidentRepository IncidentRepository
		{
			get
			{
				this._incidentRepository ??= new IncidentRepository(_context);
				return _incidentRepository;
			}


		}

		public IContactRepository ContactRepository
		{
			get
			{
				this._contactRepository ??= new ContactRepository(_context);
				return _contactRepository;
			}

		}

		public IAccountRepository AccountRepository
		{
			get
			{
				this._accountRepository ??= new AccountRepository(_context);
				return _accountRepository;
			}
		}


		public async Task<int> SaveAsync() {
			return await _context.SaveChangesAsync();
		}
	}
}