using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoStressWedding.Models
{
    public class UserItem
    {
        public int UserItemID { get; set; }
        public ItemValue ItemValue { get; set; }
        public ICollection<UserRole> UserRoles  { get; set; }

    }
}