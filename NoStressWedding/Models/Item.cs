using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NoStressWedding.Models
{
    public class Item
    {
        /*Basic still working this out*/
        public int Id { get; set; }
        public string ItemName { get; set; }
    }
   /*  public class ItemContext : DbContext {
     public DbSet<Item> Items { get; set; }
    }*/
}