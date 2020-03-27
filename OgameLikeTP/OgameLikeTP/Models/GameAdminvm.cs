using OgameLikeTPClassLibrary.Entities;
using OgameLikeTPClassLibrary.Entities.Configurations;
using System.Collections.Generic;


namespace OgameLikeTP.Models
{
    public class GameAdminVM
    {
        public GlobalGameConfiguration GlobalGameConfiguration { get; set; }

        public GlobalPlanetConfiguration GlobalPlanetConfiguration { get; set; }

        public List<Resource> Resources { get; set; }

        public List<Building> Buildings { get; set; }
    }
}