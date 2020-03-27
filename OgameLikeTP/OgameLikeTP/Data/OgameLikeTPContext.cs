using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OgameLikeTP.Data
{
    public class OgameLikeTPContext : DbContext
    {

        public OgameLikeTPContext() : base("name=OgameLikeTPContext"){}
        public DbSet<OgameLikeTPClassLibrary.Entities.SolarSystem> SolarSystems { get; set; }

        public DbSet<OgameLikeTPClassLibrary.Entities.Planet> Planets { get; set; }

        public DbSet<OgameLikeTPClassLibrary.Entities.Resource> Resources { get; set; }

        public DbSet<OgameLikeTPClassLibrary.Entities.Building> Buildings { get; set; }

        public DbSet<OgameLikeTPClassLibrary.Entities.Configuration> Configurations { get; set; }
    }
}
