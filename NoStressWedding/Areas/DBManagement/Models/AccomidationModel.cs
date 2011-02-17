using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoStressWedding.Areas.DBManagement.Models {
  public class AccomidationModel {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public AccomidationDetailModel Address { get; set; }
  }
}