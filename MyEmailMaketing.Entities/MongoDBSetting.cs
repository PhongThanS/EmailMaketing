﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEmailMaketing.Models
{
    public class MongoDBSetting
    {
        public string? ConnectionURI { get; set; }
        public string? DatabaseName { get; set; }
        public string? CollectionName { get; set; }
    }
}
