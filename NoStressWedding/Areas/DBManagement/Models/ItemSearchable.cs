namespace NoStressWedding.Areas.DBManagement.Models {
	public class ItemSearchable : Item {
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
	}
}