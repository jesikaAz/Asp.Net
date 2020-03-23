using BO;
using System.Collections.Generic;

namespace TP_dojo.Models
{
    public class SamouraiVM
        {
            public Samourai Samourai { get; set; }
            public List<Arme> Armes { get; set; }
            public int? IdSelectedArme { get; set; }
        }
}

