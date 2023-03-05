using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CRUDDemo.Data.Entities;

namespace CRUDDemo.Data
{
    public class DoujiaEntitiesDbContext : DbContext
    {
        public DoujiaEntitiesDbContext(): base("name=DoujiaEntities") { }

        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Games> Games { get; set; }
    }
}