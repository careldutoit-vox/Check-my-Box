using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NoStressWedding.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserItemList> UserItemLists { get; set; }

    }

    public class UserContext : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<User> Users { get; set; }
    }
}