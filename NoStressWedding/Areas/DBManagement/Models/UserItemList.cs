using System.Collections.Generic;
using Microsoft.Data.Entity.Ctp;

namespace NoStressWedding.Areas.DBManagement.Models {
  public class UserItemList {
    public int UserItemListId { get; set; }
		[ForeignKey("UserId")] public virtual User UserOwner { get; set; } /*This is customer who owns the list */
		public virtual ICollection<User> UserAvailable { get; set; } /*This is list of cutomers who can view the list*/
		public virtual ICollection<UserItem> UserItems { get; set; } /*This is list of Alltems on th list*/
  }

  /*
   public class UserItemListContext : DbContext {
     public DbSet<UserItemList> UserItemLists { get; set; }
   }
    */
}