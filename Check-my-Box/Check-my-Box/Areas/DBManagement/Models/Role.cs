using System.ComponentModel.DataAnnotations;

namespace Check_my_Box.Areas.DBManagement.Models {
	public class Role {
		[Key]
		public int RoleId { get; set; }
		public string Name { get; set; }
	}
}