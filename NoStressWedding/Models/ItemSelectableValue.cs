﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoStressWedding.Models
{
    public class ItemSelectableValue : ItemValue
    {
        
        public int ItemSelectableValueId { get; set; }
        public ItemSelectable ItemSelectable { get; set; }
        public string SelectableValue { get; set; }
    }
}