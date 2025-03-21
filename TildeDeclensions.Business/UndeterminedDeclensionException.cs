namespace TildeDeclensions.Business
{
    [Serializable]
    public class UndeterminedDeclensionException : Exception
    {
        public UndeterminedDeclensionException(string word)
        : base($"Could not determine declension for the word: {word}")
        {
        }
    }
}