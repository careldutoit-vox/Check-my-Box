using System.Collections.Generic;
using System.Data.Entity;

namespace NoStressWedding.Areas.DBManagement.Models {

  public class User {
    public int UserId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public virtual ICollection<UserItemList> UserItemLists { get; set; }
  }

  public class UserContext: DbContext {
    public DbSet<User> Users { get; set; }
  }
}