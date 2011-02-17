using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoStressWedding.Models
{
    public class CategoryAttributeValue
    {
        public int CategoryAttributeValueId {get;set;}
        public CategoryAttribute CategoryAttribute { get; set; }
        public string Value { get; set; }
    }
}