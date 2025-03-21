namespace TildeDeclensions.Business.DeclensionRules
{
    public class FourthDeclensionRule001 : IRule
    {

        private const string NECESSARY_SUFFIX = "a";
        public bool Evaluate(string word)
        {
            return word.EndsWith(NECESSARY_SUFFIX);
        }
    }
}
