namespace NoStressWedding.Areas.DBManagement.Models {
  public class ItemSearchableValue: ItemValue {
    public int ItemSearchableValueId { get; set; }
		public int ItemSearchableId { get; set; }
    public virtual ItemSearchable ItemSearchable { get; set; }
		public int SearchableElementId { get; set; }
		public virtual SearchableElement SearchableElement { get; set; }
  }
}