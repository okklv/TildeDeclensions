namespace TildeDeclensions.Business.DeclensionRules
{
    public class FirstDeclensionRule001 : IRule
    {

        private const string NECESSARY_SUFFIX = "s";
        public bool Evaluate(string word)
        {
            return word.EndsWith(NECESSARY_SUFFIX, StringComparison.OrdinalIgnoreCase);
        }
    }
}
