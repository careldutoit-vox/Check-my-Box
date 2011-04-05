using System.Collections.Generic;

namespace NoStressWedding.Areas.DBManagement.Models {
	public class UserItem {
		public int UserItemId { get; set; }
		public int ItemValueId { get; set; }
		public virtual ItemValue ItemValue { get; set; }
		public virtual ICollection<UserRole> UserRoles { get; set; }
		public int ItemOrder { get; set; }
		public virtual ICollection<UserItem> UserItems { get; set; } /*This is list of Alltems on th list*/
	}
}