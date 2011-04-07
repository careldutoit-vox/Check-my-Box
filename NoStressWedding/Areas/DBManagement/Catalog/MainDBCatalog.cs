using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NoStressWedding.Areas.DBManagement.Models;

namespace NoStressWedding.Areas.DBManagement.Catalog {
  public class MainDBCatalog : DbContext {

    public MainDBCatalog() { }


    public DbSet<AccomidationModel> AccomidationModels { get; set; }
    public DbSet<AccomidationDetailModel> AccomidationDetailModels { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<CategoryAttribute> CategoryAttribute { get; set; }
		public DbSet<CategoryAttributeValue> CategoryAttributeValue { get; set; }
		public DbSet<Item> Item { get; set; }
		public DbSet<ItemSearchable> ItemSearchable { get; set; }
		public DbSet<ItemSearchableValue> ItemSearchableValue { get; set; }
		public DbSet<ItemSelectable> ItemSelectable { get; set; }
		public DbSet<ItemSelectableValue> ItemSelectableValue { get; set; }
		public DbSet<ItemText> ItemTexts { get; set; }
		public DbSet<ItemTextValue> ItemTextValues { get; set; }
		public DbSet<ItemValue> ItemValues { get; set; }
		public DbSet<SearchableElement> SearchableElements { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserItem> UserItems { get; set; }
		public DbSet<UserItemList> UserItemLists { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }


  }
}