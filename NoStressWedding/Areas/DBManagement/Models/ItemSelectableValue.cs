namespace NoStressWedding.Areas.DBManagement.Models {
  public class ItemSelectableValue: ItemValue {

    public int ItemSelectableValueId { get; set; }
		public string SelectableValue { get; set; }

		public int ItemSelectableId { get; set; }
    public virtual ItemSelectable ItemSelectable { get; set; }
   
  }
}