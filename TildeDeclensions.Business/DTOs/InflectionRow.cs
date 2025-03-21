namespace TildeDeclensions.Business.DTOs
{
    public struct InflectionRow
    {
        public string Nominative { get; set; }
        public string Genitive { get; set; }
        public string Dative { get; set; }
        public string Accusative { get; set; }
        public string Instrumental { get; set; }
        public string Locative { get; set; }
        public string Vocative { get; set; }

        public InflectionRow(string nominative, string genitive, string dative, string accusative, string instrumental, string locative, string vocative)
        {
            Nominative = nominative;
            Genitive = genitive;
            Dative = dative;
            Accusative = accusative;
            Instrumental = instrumental;
            Locative = locative;
            Vocative = vocative;
        }
    }
}
