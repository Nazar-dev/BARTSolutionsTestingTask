using System;

namespace BARTSolutionsTestingTask.BL.Models {
	public class ContactModel {
		
		public string Email { get; set; }
		
		public Guid AccountId { get; set; }
		
		public string FirstName { get; set; }
		
		public string LastName { get; set; }
	}
}