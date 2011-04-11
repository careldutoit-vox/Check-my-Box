namespace Check_my_Box.Areas.DBManagement.Models {
	public class CategoryAttributeValue {
		public int CategoryAttributeValueId { get; set; }
		public int CategoryAttributeId { get; set; }
		public virtual CategoryAttribute CategoryAttribute { get; set; }
		public string Value { get; set; }
	}
}