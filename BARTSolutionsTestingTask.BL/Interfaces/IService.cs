using System.Collections.Generic;
using System.Threading.Tasks;

namespace BARTSolutionsTestingTask.BL.Services {
	
	public interface IService<T> where T : class {
		Task<IEnumerable<T>> GetAllAsync();

		Task AddAsync(T model);

	}
}