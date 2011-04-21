using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Check_my_Box.Areas.DBManagement.Models;

namespace Check_my_Box.Areas.DBManagement.Catalog {
	public class MainDBContextInitializer
		: DropCreateDatabaseIfModelChanges<MainDBCatalog> {
		protected override void Seed(MainDBCatalog context) {
			//create sample data and attach it to the context.

			new List<User>
   {
    new User { Name = "Michael", LastName = "Marriott",
                TelephoneNumber= "011"}
   }.ForEach(b => context.Users.Add(b));

			base.Seed(context);

		}
	}
}