﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrevithickP3.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public IEnumerable<Post> Posts { get; set; }

    }
}
