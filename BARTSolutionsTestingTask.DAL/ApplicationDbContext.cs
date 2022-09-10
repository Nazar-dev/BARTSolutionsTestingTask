using BARTSolutionsTestingTask.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace BARTSolutionsTestingTask.DAL {
	public class ApplicationDbContext:DbContext {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
		{
		}
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Incident> Incidents { get; set; }
		public DbSet<Contact> Contacts { get; set; }

	}
}