using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoStressWedding.Models
{
    public class ItemTextValue : ItemValue
    {
        public int ItemTextValueId { get; set; }
        public ItemText ItemText { get; set; }
        public string TextValue { get; set; }
    }
}