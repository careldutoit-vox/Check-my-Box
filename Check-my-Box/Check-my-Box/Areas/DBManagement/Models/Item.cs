using System.ComponentModel.DataAnnotations;

namespace Check_my_Box.Areas.DBManagement.Models {
	public class Item {
		[Key]
		public int Id { get; set; }
		public string ItemName { get; set; }
	}

}