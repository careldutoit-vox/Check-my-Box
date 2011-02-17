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
    
  }
}