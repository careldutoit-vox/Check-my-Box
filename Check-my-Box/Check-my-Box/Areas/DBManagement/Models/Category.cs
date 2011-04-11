using System.Collections.ObjectModel;

namespace Check_my_Box.Areas.DBManagement.Models {
	public class Category {
		public int CategoryId { get; set; }
		public string Name { get; set; }
		public virtual Collection<CategoryAttributeValue> CategoryAttributeValues { get; set; }
	}
}