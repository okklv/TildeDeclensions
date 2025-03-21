namespace TildeDeclensions.Business.DeclensionRules
{
    public class AdjectiveComparativeDeclensionRule001 : IRule
    {

        private const string NECESSARY_SUFFIX = "āks";
        public bool Evaluate(string word)
        {
            return word.EndsWith(NECESSARY_SUFFIX, StringComparison.OrdinalIgnoreCase);
        }
    }
}
