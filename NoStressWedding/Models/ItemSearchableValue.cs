using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoStressWedding.Models
{
    public class ItemSearchableValue : ItemValue
    {

        public int ItemSearchableValueId { get; set; }
        public ItemSearchable ItemSearchable { get; set; }
        public SearchableElement SearchableElement { get; set; }
    }
}