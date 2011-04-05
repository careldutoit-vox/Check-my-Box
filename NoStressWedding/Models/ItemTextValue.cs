namespace NoStressWedding.Models {
  public class ItemTextValue: ItemValue {
    public int ItemTextValueId { get; set; }
    public ItemText ItemText { get; set; }
    public string TextValue { get; set; }
  }
}