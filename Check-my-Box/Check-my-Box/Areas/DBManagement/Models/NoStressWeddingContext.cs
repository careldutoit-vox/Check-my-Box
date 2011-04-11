using System.Data.Entity;

namespace Check_my_Box.Areas.DBManagement.Models {
	public class Check_my_BoxContext: DbContext {
		public DbSet<ItemValue> ItemValues { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<UserRole> UserRoles { get; set; }

		public DbSet<ItemText> ItemTexts { get; set; }

		public DbSet<UserItem> UserItems { get; set; }

		public DbSet<UserItemList> UserItemLists { get; set; }

		public DbSet<User> Users { get; set; }
	}
}