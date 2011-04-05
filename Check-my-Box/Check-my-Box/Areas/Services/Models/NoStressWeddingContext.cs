using System.Data.Entity;
using NoStressWedding.Areas.DBManagement.Models;

namespace NoStressWedding.Areas.Services.Models {
	public class NoStressWeddingContext: DbContext {
		public DbSet<UserItemList> UserItemLists { get; set; }

		public DbSet<UserItem> UserItems { get; set; }

		public DbSet<User> Users { get; set; }
	}
}