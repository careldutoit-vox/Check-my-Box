using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//using Microsoft.Data.Entity.Ctp;

namespace Check_my_Box.Areas.DBManagement.Models {
	public class UserItemList {

		[Key]
		[Required]
		public int UserItemListId { get; set; }
		
		public int UserId { get; set; }
		[ForeignKey("UserId")]
		public virtual User UserOwner { get; set; }

		/*This is customer who owns the list */

		public virtual ICollection<User> UserAvailable { get; set; } /*This is list of cutomers who can view the list*/
		public virtual ICollection<UserItem> UserItems { get; set; } /*This is list of Alltems on th list*/
	}

}