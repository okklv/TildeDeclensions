namespace TildeDeclensions.Business.DTOs
{
    public class AdjectiveInflectionData : InflectionData
    {
        public InflectionRow MaleSingularRow { get; set; }
        public InflectionRow MalePluralRow { get; set; }
        public InflectionRow FemaleSingularRow { get; set; }
        public InflectionRow FemalePluralRow { get; set; }
    }
}
