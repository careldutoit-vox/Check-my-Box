using System.ComponentModel.DataAnnotations;

namespace Check_my_Box.Areas.DBManagement.Models {
	public class ItemSelectableValue: ItemValue {

		public string ListOptionValue { get; set; }

		public int ItemSelectableId { get; set; }
		[ForeignKey("ItemSelectableId")]
		public virtual ItemSelectable ItemSelectable { get; set; }
	}
}