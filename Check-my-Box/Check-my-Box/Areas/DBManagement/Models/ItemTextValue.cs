using System.ComponentModel.DataAnnotations;

namespace Check_my_Box.Areas.DBManagement.Models {
	public class ItemTextValue: ItemValue {

		public string TextValue { get; set; }

		public int ItemTextId { get; set; }
		[ForeignKey("ItemTextId")]
		public virtual ItemText ItemText { get; set; }
	}
}