using System.Collections.Generic;

namespace NoStressWedding.Models {
  public class UserItem {
    public int UserItemId { get; set; }
    public ItemValue ItemValue { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    public int ItemOrder { get; set; }
    public ICollection<UserItem> UserItems { get; set; } /*This is list of Alltems on th list*/
  }
}