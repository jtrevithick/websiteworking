﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrevithickP3.Models
{
    public class BlogPostViewModel
    {
        public Blog Blog { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
