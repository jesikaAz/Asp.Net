using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OgameLikeTP.Data
{
    public class OgameLikeTPContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public OgameLikeTPContext() : base("name=OgameLikeTPContext")
        {
        }

        public DbSet<OgameLikeTPClassLibrary.Entities.SolarSystem> SolarSystems { get; set; }

        public DbSet<OgameLikeTPClassLibrary.Entities.Planet> Planets { get; set; }

        public DbSet<OgameLikeTPClassLibrary.Entities.Resource> Resources { get; set; }
    }
}
