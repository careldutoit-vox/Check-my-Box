using System.Data.Entity;
using Check_my_Box.Areas.DBManagement.Models;

namespace Check_my_Box.Areas.Services.Models {
	public class Check_my_BoxContext: DbContext {
		public DbSet<UserItemList> UserItemLists { get; set; }

		public DbSet<UserItem> UserItems { get; set; }

		public DbSet<User> Users { get; set; }
	}
}