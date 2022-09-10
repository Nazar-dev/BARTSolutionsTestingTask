using System.Collections.Generic;
using System.Threading.Tasks;

namespace BARTSolutionsTestingTask.DAL.Interfaces {
	public interface IRepository<T> where T : class {
		Task<IEnumerable<T>> GetAllAsync();
		Task Create(T item);
	}

}