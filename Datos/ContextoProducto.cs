using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuitoText_1._0.Datos
{
    public class ContextoProducto: DbContext
    {
        public ContextoProducto() : base("QuitoTexEntities") { }
        public DbSet<PRODUCTO> PRODUCTOs { get; set; }
    }
}