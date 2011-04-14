using System.ComponentModel.DataAnnotations;

namespace Check_my_Box.Areas.DBManagement.Models {
	public class CategoryAttributeValue {
		[Key]
		public int CategoryAttributeValueId { get; set; }

		public int CategoryAttributeId { get; set; }
		[ForeignKey("CategoryAttributeId")]
		public virtual CategoryAttribute CategoryAttribute { get; set; }

		public string Value { get; set; }

	}
}