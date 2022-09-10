using System;
using System.Collections.Generic;

namespace BARTSolutionsTestingTask.BL.Models {
	public class IncidentModel {
		
		public string Name { get; set; }
		
		public IEnumerable<Guid> AccountsId { get; set; }
		
		public string Description { get; set; }
	}
}