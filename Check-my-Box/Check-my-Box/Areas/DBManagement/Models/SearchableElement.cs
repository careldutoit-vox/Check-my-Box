using System.Collections.Generic;

namespace Check_my_Box.Areas.DBManagement.Models {
	public class SearchableElement {
		public int SearchableElementId { get; set; }
		public virtual ICollection<Category> Categorys { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ICollection<CategoryAttributeValue> CategoryAttributeValues { get; set; }
	}
}