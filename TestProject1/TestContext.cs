﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TestProject1
{
    public class TestContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
