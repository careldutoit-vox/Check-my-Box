using System.Data.Entity;

namespace NoStressWedding.Areas.DBManagement.Models {
	public class NoStressWeddingContext: DbContext {
		public DbSet<ItemValue> ItemValues { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<UserRole> UserRoles { get; set; }

		public DbSet<ItemText> ItemTexts { get; set; }

		public DbSet<UserItem> UserItems { get; set; }

		public DbSet<UserItemList> UserItemLists { get; set; }

		public DbSet<User> Users { get; set; }
	}
}