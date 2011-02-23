using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NoStressWedding.Areas.DBManagement.Models
{
    public class NoStressWeddingContext : DbContext
    {
			public DbSet<NoStressWedding.Areas.DBManagement.Models.ItemValue> ItemValues { get; set; }
		
			public DbSet<NoStressWedding.Areas.DBManagement.Models.Role> Roles { get; set; }
		
			public DbSet<NoStressWedding.Areas.DBManagement.Models.UserRole> UserRoles { get; set; }
		
			public DbSet<NoStressWedding.Areas.DBManagement.Models.ItemText> ItemTexts { get; set; }
		
			public DbSet<NoStressWedding.Areas.DBManagement.Models.UserItem> UserItems { get; set; }
		
			public DbSet<NoStressWedding.Areas.DBManagement.Models.UserItemList> UserItemLists { get; set; }
		
			public DbSet<NoStressWedding.Areas.DBManagement.Models.User> Users { get; set; }
		
        public NoStressWeddingContext()
        {
            // Instructions:
            //  * You can add custom code to this file. Changes will *not* be lost when you re-run the scaffolder.
            //  * If you want to regenerate the file totally, delete it and then re-run the scaffolder.
            //  * You can delete these comments if you wish
            //  * If you want Entity Framework to drop and regenerate your database automatically whenever you 
            //    change your model schema, uncomment the following line:
			//    DbDatabase.SetInitializer(new DropCreateDatabaseIfModelChanges<NoStressWeddingContext>());
        }
    }
}