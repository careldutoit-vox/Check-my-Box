using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Check_my_Box.Areas.DBManagement.Models {
	public class User {

		[Key]
		[Required]
		public int UserId { get; set; }
		[Required(ErrorMessage = "Name must be specified")]
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string TelephoneNumber { get; set; }
		public virtual ICollection<UserItemList> UserItemLists { get; set; }
	}

	//public class UserContext: DbContext {
	//  public DbSet<User> Users { get; set; }
	//}
}