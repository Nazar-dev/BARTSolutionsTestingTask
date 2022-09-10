using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BARTSolutionsTestingTask.BL.Interfaces;
using BARTSolutionsTestingTask.BL.Models;
using BARTSolutionsTestingTask.DAL.Entity;
using BARTSolutionsTestingTask.DAL.Interfaces;

namespace BARTSolutionsTestingTask.BL.Services {
	public class ContactService : IContactService {
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public ContactService(IUnitOfWork unitOfWork, IMapper mapper) {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<IEnumerable<ContactModel>> GetAllAsync() {
			return _mapper.Map<IEnumerable<ContactModel>>(await _unitOfWork.ContactRepository.GetAllAsync());
		}
		public async Task AddAsync(ContactModel model) {
			await _unitOfWork.ContactRepository.Create(_mapper.Map<Contact>(model));
		}
		public async Task<ContactModel> GetBy(string email) {
			return _mapper.Map<ContactModel>(await _unitOfWork.ContactRepository.GetBy(email));
		}
		public async Task<int> Update(ContactModel contactModel) {

			if (contactModel.AccountId == Guid.Empty) {
				contactModel.AccountId = _unitOfWork.AccountRepository.GetByEmail(contactModel.Email).Result.AccountId;
			} 
			_unitOfWork.ContactRepository.Update(_mapper.Map<Contact>(contactModel));
			return await _unitOfWork.SaveAsync();
		}
	}
}