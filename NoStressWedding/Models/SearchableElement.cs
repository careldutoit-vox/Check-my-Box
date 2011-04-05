using System.Collections.Generic;

namespace NoStressWedding.Models {
  public class SearchableElement {
    public int SearchableElementId { get; set; }
    public ICollection<Category> Categorys { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<CategoryAttributeValue> CategoryAttributeValues { get; set; }
  }
}