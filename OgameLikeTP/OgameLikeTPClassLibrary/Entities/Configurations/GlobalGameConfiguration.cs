using System.ComponentModel;

namespace OgameLikeTPClassLibrary.Entities.Configurations
{
    public class GlobalGameConfiguration
    {
        [DisplayName("Nombre de système solaire :")]
        public int? SolarSystemNb { get; set; }

        [DisplayName("Nombre de planète par système :")]
        public int? PlanetsNb { get; set; }
    }
}