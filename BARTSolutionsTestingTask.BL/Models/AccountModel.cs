using System;
using System.Collections.Generic;

namespace BARTSolutionsTestingTask.BL.Models {
	public class AccountModel {

		public Guid AccountId { get; set; }

		public string Email { get; set; }

		public string IncidentName { get; set; }

		public IEnumerable<string> ContactEmails { get; set; }
 
		public string Name { get; set; }
	}
}