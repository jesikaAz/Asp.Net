using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TP_dojo.Models
{
    public class Context: DbContext
    {
        public DbSet<BO.Samourai> Samourais { get; set; }

        public DbSet<BO.Arme> Armes { get; set; }

    }
}