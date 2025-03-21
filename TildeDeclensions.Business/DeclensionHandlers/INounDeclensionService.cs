using TildeDeclensions.Business.DTOs;

namespace TildeDeclensions.Business.DeclensionServices
{
    public interface INounDeclensionService
    {
        public InflectionRow GetSingularRow(string word);
        public InflectionRow GetPluralRow(string word);
    }
}
