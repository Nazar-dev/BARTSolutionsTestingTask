using System.Collections.Generic;
using System.Threading.Tasks;
using BARTSolutionsTestingTask.DAL.Entity;
using BARTSolutionsTestingTask.DAL.Interfaces;

namespace BARTSolutionsTestingTask.DAL.Repository {
	public class IncidentRepository : IIncidentRepository {
		private readonly ApplicationDbContext _context;
		public IncidentRepository(ApplicationDbContext context) {
			_context = context;
		}
		public async Task<IEnumerable<Incident>> GetAllAsync() {
			return _context.Incidents;
		}
		public async Task Create(Incident item) {
			await _context.AddAsync(item);
		}

	}
}