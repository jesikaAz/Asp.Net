using OgameLikeTPClassLibrary.Annotations;

namespace OgameLikeTPClassLibrary.Entities
{
    public enum ConfigurationKeys
    {
        [EnumNaming(Name = "GlobalGameConfiguration")]
        GlobalGameConfiguration,

        [EnumNaming(Name = "GlobalPlanetConfiguration")]
        GlobalPlanetConfiguration,
    }
}