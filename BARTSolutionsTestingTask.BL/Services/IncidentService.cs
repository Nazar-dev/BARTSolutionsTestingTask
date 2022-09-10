using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BARTSolutionsTestingTask.BL.Interfaces;
using BARTSolutionsTestingTask.BL.Models;
using BARTSolutionsTestingTask.DAL.Entity;
using BARTSolutionsTestingTask.DAL.Interfaces;

namespace BARTSolutionsTestingTask.BL.Services {
	public class IncidentService : IIncidentService {
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public IncidentService(IUnitOfWork unitOfWork, IMapper mapper) {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<IEnumerable<IncidentModel>> GetAllAsync() {
			return _mapper.Map<IEnumerable<IncidentModel>>(await _unitOfWork.IncidentRepository.GetAllAsync());
		}
		public async Task AddAsync(IncidentModel model) {
			await _unitOfWork.IncidentRepository.Create(_mapper.Map<Incident>(model));
			await _unitOfWork.SaveAsync();
		}
	}
}