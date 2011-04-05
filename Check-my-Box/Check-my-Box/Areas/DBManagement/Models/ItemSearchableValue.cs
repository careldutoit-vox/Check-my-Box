using System.ComponentModel.DataAnnotations;

namespace NoStressWedding.Areas.DBManagement.Models {
	public class ItemSearchableValue: ItemValue {
		public int ItemSearchableValueId { get; set; }

		[ForeignKey("ItemSearchableId")]
		public int ItemSearchableId { get; set; }
		public virtual ItemSearchable ItemSearchable { get; set; }


		public int SearchableElementId { get; set; }
		[ForeignKey("SearchableElementId")]
		public virtual SearchableElement SearchableElement { get; set; }
	}
}