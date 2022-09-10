using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace BARTSolutionsTestingTask.DAL.Entity {
	public class Incident {
		[Key]
		public string Name { get; set; }
		
		public string Description { get; set; }
		
		public IEnumerable<Account> Accounts { get; set; }
	}
}