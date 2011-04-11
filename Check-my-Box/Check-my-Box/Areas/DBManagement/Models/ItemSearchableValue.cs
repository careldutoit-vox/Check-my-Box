using System.ComponentModel.DataAnnotations;

namespace Check_my_Box.Areas.DBManagement.Models {
	public class ItemSearchableValue: ItemValue {
		//public int ItemSearchableValueId { get; set; }

		
//		public int ItemSearchableId { get; set; }
//		[ForeignKey("ItemSearchableId")]
		public virtual ItemSearchable ItemSearchable { get; set; }


//		public int SearchableElementId { get; set; }
//		[ForeignKey("SearchableElementId")]
		public virtual SearchableElement SearchableElement { get; set; }
	}
}