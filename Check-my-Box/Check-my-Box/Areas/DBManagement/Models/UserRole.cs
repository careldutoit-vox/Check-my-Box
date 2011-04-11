using System.ComponentModel.DataAnnotations;

namespace Check_my_Box.Areas.DBManagement.Models {
	public class UserRole {
		[Key]
		public int UserRoleId { get; set; }

		public int UserId { get; set; }
		[ForeignKey("UserId")]
		public virtual User User { get; set; }

		public int RoleId { get; set; }
		[ForeignKey("RoleId")]
		public virtual Role Role { get; set; }
	}
}