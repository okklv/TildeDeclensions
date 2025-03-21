namespace TildeDeclensions.Business.DeclensionRules
{
    public interface IRule
    {
        bool Evaluate(string word);
    }
}
