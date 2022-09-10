using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace BARTSolutionsTestingTask.DAL.Entity {
	public class Account {
		[Key] 
		public Guid AccountId { get; set; }
		
		public string Name { get; set; }

		public IEnumerable<Contact> Contacts { get; set; }

		public Incident Incident { get; set; }


	}
}