using TildeDeclensions.Business.DTOs;

namespace TildeDeclensions.Business.DeclensionServices
{
    public interface IDeclensionHandler
    {
        IDeclensionHandler SetNext(IDeclensionHandler next);
        InflectionData Handle(string word);
    }
}