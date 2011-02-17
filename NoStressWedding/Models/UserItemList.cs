using System.Collections.Generic;

namespace NoStressWedding.Models {
  public class UserItemList {
    public int UserItemListId { get; set; }
    // public User UserOwner { get; set; } /*This is customer who owns the list */
    public ICollection<User> UserAvailable { get; set; } /*This is list of cutomers who can view the list*/
    public ICollection<UserItem> UserItems { get; set; } /*This is list of Alltems on th list*/
  }

  /*
   public class UserItemListContext : DbContext {
     public DbSet<UserItemList> UserItemLists { get; set; }
   }
    */
}