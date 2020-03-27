using System.Collections.Generic;
using System.ComponentModel;


namespace OgameLikeTPClassLibrary.Entities.Configurations
{
    public class GlobalPlanetConfiguration
    {
        [DisplayName("Type de ressource des planètes :")]
        public List<int> ResourcesIds { get; set; }

        [DisplayName("Batiments disponible par planètes :")]
        public List<int> BuildingsIds { get; set; }
    }
}