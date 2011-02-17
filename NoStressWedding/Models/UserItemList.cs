using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace NoStressWedding.Models
{
   public class UserItemList {
        
       public int UserItemListId {get;set;}
       public virtual User UserOwner { get; set; } /*This is customer who owns the list */
       public virtual ICollection<User> UsersAvailable { get; set; }  /*This is list of cutomers who can view the list*/
       public virtual ICollection<UserItem> UserItems { get; set; }  /*This is list of Alltems on th list*/

   }
    /*
   public class UserItemListContext : DbContext {
     public DbSet<UserItemList> UserItemLists { get; set; }
   }
    */
}
