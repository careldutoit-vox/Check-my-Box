using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Check_my_Box.Areas.DBManagement.Models {
	public class UserItem {
		[Key]
		[Required]
		public int UserItemId { get; set; }

		public int ItemValueId { get; set; }

		[ForeignKey("ItemValueId")]
		public virtual ItemValue ItemValue { get; set; }

	//	public virtual ICollection<UserRole> UserRoles { get; set; }
		public int ItemOrder { get; set; }
	
	}
}