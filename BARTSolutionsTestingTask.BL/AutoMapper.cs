using AutoMapper;
using BARTSolutionsTestingTask.BL.Models;
using BARTSolutionsTestingTask.DAL.Entity;

namespace BARTSolutionsTestingTask.BL {
	public class AutoMapper : Profile {

		public AutoMapper() {
			CreateMap<Account, AccountModel>().ReverseMap();
			CreateMap<Incident, IncidentModel>().ReverseMap();
			CreateMap<Contact, ContactModel>().ReverseMap();
		}
	}
}