using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Check_my_Box.Areas.DBManagement.Models {
	public class Category {
		[Key]
		public int CategoryId { get; set; }
		public string Name { get; set; }
		public virtual Collection<CategoryAttributeValue> CategoryAttributeValues { get; set; }
	}
}