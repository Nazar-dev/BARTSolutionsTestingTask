using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BARTSolutionsTestingTask.BL.Interfaces;
using BARTSolutionsTestingTask.BL.Models;
using BARTSolutionsTestingTask.DAL.Entity;
using BARTSolutionsTestingTask.DAL.Interfaces;

namespace BARTSolutionsTestingTask.BL.Services {
	public class AccountService:IAccountService {

		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		
		public AccountService(IUnitOfWork unitOfWork, IMapper mapper) {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<IEnumerable<AccountModel>> GetAllAsync() {
			return _mapper.Map<IEnumerable<AccountModel>>(await _unitOfWork.AccountRepository.GetAllAsync());
		}
		public async Task AddAsync(AccountModel model) {
			await _unitOfWork.AccountRepository.Create(_mapper.Map<Account>(model));
			await _unitOfWork.SaveAsync();
		}
		public async Task<AccountModel> GetBy(string name) {
			return _mapper.Map<AccountModel>(await _unitOfWork.AccountRepository.GetBy(name));
		}
		public async Task<AccountModel> GetByEmail(string email) {
			return _mapper.Map<AccountModel>(await _unitOfWork.AccountRepository.GetByEmail(email));

		}
		public async Task<IEnumerable<ContactModel>> GetContactsByName(string name) {
			return _mapper.Map<IEnumerable<ContactModel>>(await _unitOfWork.AccountRepository.GetContactsByName(name));
		}
		public async Task LinkContact(string name, ContactModel contactModel) {
			await _unitOfWork.AccountRepository.LinkContact(name, _mapper.Map<Contact>(contactModel));
			await _unitOfWork.SaveAsync();
			
		}
	}
}