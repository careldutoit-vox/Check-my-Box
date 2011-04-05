using System.ComponentModel.DataAnnotations;

namespace NoStressWedding.Areas.DBManagement.Models {
	public class ItemSelectableValue: ItemValue {
		[Key]
		public int ItemSelectableValueId { get; set; }

		public string ListOptionValue { get; set; }

		public int ItemSelectableId { get; set; }
		[ForeignKey("ItemSelectableId")]
		public virtual ItemSelectable ItemSelectable { get; set; }
	}
}