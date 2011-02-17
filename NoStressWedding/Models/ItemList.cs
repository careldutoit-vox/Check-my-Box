using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoStressWedding.Models
{
    public class ItemList
    {
        /*Basic still working this out*/
        public int ItemListId { get; set; }
        public ICollection<UserItem> UserItems { get; set; }
    }
}