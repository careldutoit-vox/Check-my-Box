using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoStressWedding.Models {
  public class UserRole {
    public int UserRoleID { get; set; }
    public User User { get; set; }
    public Role Role { get; set; }
  }
}