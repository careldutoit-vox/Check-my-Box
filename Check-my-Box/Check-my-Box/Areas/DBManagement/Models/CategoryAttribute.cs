using System.ComponentModel.DataAnnotations;

namespace Check_my_Box.Areas.DBManagement.Models {
	public class CategoryAttribute {
		[Key]
		public int CategoryAttributeId { get; set; }
		public string Name { get; set; }
	}
}