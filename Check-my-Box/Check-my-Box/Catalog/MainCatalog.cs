using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using NoStressWedding.Areas.DBManagement.Models;

namespace NoStressWedding.Catalog
{
    public class MainCatalog : System.Data.Entity.DbContext

    {
        public MainCatalog()
           
        { }


       /* public MainCatalog(DbModel model)
            : base(model)
        { }
        */
        public System.Data.Entity.DbSet<User> Users { get; set; }
        public System.Data.Entity.DbSet<Item> Items { get; set; }
        public System.Data.Entity.DbSet<Role> Roles { get; set; }
        public System.Data.Entity.DbSet<UserItem> UserItems { get; set; }
        public System.Data.Entity.DbSet<UserItemList> UserItemLists { get; set; }
        public System.Data.Entity.DbSet<UserRole> UserRoles { get; set; }

        public System.Data.Entity.DbSet<ItemValue> ItemValues { get; set; }

        public System.Data.Entity.DbSet<ItemText> ItemTexts { get; set; }
        public System.Data.Entity.DbSet<ItemTextValue> ItemTextValues { get; set; }

        public System.Data.Entity.DbSet<ItemSearchable> ItemSearchables { get; set; }
        public System.Data.Entity.DbSet<ItemSearchableValue> ItemSearchableValues { get; set; }

        public System.Data.Entity.DbSet<ItemSelectable> ItemSelectables { get; set; }
        public System.Data.Entity.DbSet<ItemSelectableValue> ItemSelectableValues { get; set; }
        public System.Data.Entity.DbSet<SearchableElement> SearchableElements { get; set; }

        public System.Data.Entity.DbSet<Category> Categorys { get; set; }
        //public System.Data.Entity.DbSet<CategoryAttribute> CategoryAttibutes { get; set; }
        public System.Data.Entity.DbSet<CategoryAttributeValue> CategoryAttributeValues { get; set; }


    }
}