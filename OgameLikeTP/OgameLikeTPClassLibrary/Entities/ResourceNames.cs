using OgameLikeTPClassLibrary.Annotations;


namespace OgameLikeTPClassLibrary.Entities
{
    public enum ResourceNames
    {
        [EnumNaming(Name = "énergie")]
        Energy,
        [EnumNaming(Name = "oxygène")]
        Oxygen,
        [EnumNaming(Name = "acier")]
        Steel,
        [EnumNaming(Name = "uranium")]
        Uranium
    }
}