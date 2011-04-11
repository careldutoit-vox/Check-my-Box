using System.Data.Entity;
using Check_my_Box.Areas.DBManagement.Models;

namespace Check_my_Box.Areas.DBManagement.Catalog {


	public class MainDBCatalog: DbContext {

		public DbSet<AccomidationModel> AccomidationModels { get; set; }
		public DbSet<AccomidationDetailModel> AccomidationDetailModels { get; set; }
		public DbSet<Category> Categorys { get; set; }
		public DbSet<CategoryAttribute> CategoryAttributes { get; set; }
		public DbSet<CategoryAttributeValue> CategoryAttributeValues { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<ItemSearchable> ItemSearchables { get; set; }
		public DbSet<ItemSearchableValue> ItemSearchableValues { get; set; }
		public DbSet<ItemSelectable> ItemSelectables { get; set; }
		public DbSet<ItemSelectableValue> ItemSelectableValues { get; set; }
		public DbSet<ItemText> ItemTexts { get; set; }
		public DbSet<ItemTextValue> ItemTextValues { get; set; }
		public DbSet<ItemValue> ItemValues { get; set; }
		public DbSet<SearchableElement> SearchableElements { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserItem> UserItems { get; set; }
		public DbSet<UserItemList> UserItemLists { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {


		
			modelBuilder.Entity<Item>().ToTable("Items");
			modelBuilder.Entity<ItemSearchable>().ToTable("ItemSearchables");

			modelBuilder.Entity<Item>().ToTable("Items");
			modelBuilder.Entity<ItemText>().ToTable("ItemTexts");

			modelBuilder.Entity<Item>().ToTable("Items");
			modelBuilder.Entity<ItemSelectable>().ToTable("ItemSelectables");
			
			modelBuilder.Entity<ItemValue>().ToTable("ItemValues");
			modelBuilder.Entity<ItemSearchableValue>().ToTable("ItemSearchableValues");

			modelBuilder.Entity<ItemValue>().ToTable("ItemValues");
			modelBuilder.Entity<ItemTextValue>().ToTable("ItemTextValues");

			modelBuilder.Entity<ItemValue>().ToTable("ItemValues");
			modelBuilder.Entity<ItemSelectableValue>().ToTable("ItemSelectableValues");


//			modelBuilder.Entity<Item>()
	//	.Map<Item>(m => m.Requires("Type").HasValue("Current"))
		//.Map<ItemSearchable>(m => m.Requires("Type").HasValue("Old")); 
		}

		/*
		
	protected override void OnModelCreating(DbModelBuilder modelBuilder){
		modelBuilder.Entity<User>()
.HasMany(s => s.UserItemLists)
.WithMany()
.Map(m => {
	m.MapLeftKey(s => s., "UserId");
	m.MapRightKey(r => r.ReportTypeID, "ReportType");
	m.ToTable("T_SYSTEM_REPORT_TYPE_XREF");
});

    modelBuilder.Entity<User>()
                .HasOptional(x => x.DefaultAirport)
                .WithMany()
                .HasForeignKey(n => n.DefaultAirportID);        
	}

*/




	}
}