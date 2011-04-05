using System.ComponentModel.DataAnnotations;

namespace NoStressWedding.Areas.DBManagement.Models {
  public class ItemTextValue: ItemValue {
		[Key] 
    public int ItemTextValueId { get; set; }
		public string TextValue { get; set; }

		public int ItemTextId { get; set; }
		public virtual ItemText ItemText { get; set; }
    
  }
}