using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BARTSolutionsTestingTask.DAL.Entity {
	public class Contact {
		[Key]
		public string Email { get; set; }
		
		public string FirstName { get; set; }
		
		public string LastName { get; set; }
		
		public Account Account { get; set; }
	}
} 