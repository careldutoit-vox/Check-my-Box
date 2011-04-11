using System.ComponentModel.DataAnnotations;

namespace Check_my_Box.Areas.DBManagement.Models {
	public class ItemValue {
		[Key]
		public int ItemValueId { get; set; }

		public string PlaceHolder { get; set; }
	}
}