namespace TildeDeclensions.Business.DeclensionRules
{
    public class FirstDeclensionRule002 : IRule
    {

        private const string EXCEPTION_FIRST_DECLENSION_SUFFIX = "āks";
        public bool Evaluate(string word)
        {
            return !word.EndsWith(EXCEPTION_FIRST_DECLENSION_SUFFIX, StringComparison.OrdinalIgnoreCase);
        }
    }
}
