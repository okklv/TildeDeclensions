using TildeDeclensions.Business.DeclensionRules;
using TildeDeclensions.Business.DTOs;

namespace TildeDeclensions.Business.DeclensionServices
{
    public class AdjectiveComparativeDeclensionHandler : BaseDeclensionHandler
    {
        private INounDeclensionService _firstDeclensionService;
        private INounDeclensionService _fourthDeclensionService;

        public AdjectiveComparativeDeclensionHandler(IEnumerable<IRule> rules, INounDeclensionService firstDeclensionService, INounDeclensionService fourthDeclensionService) : base(rules)
        {
            _firstDeclensionService = firstDeclensionService;
            _fourthDeclensionService = fourthDeclensionService;
        }

        protected override InflectionData Process(string word)
        {
            var result = new AdjectiveInflectionData
            {
                MaleSingularRow = _firstDeclensionService.GetSingularRow(word),
                MalePluralRow = _firstDeclensionService.GetPluralRow(word),
                FemaleSingularRow = _fourthDeclensionService.GetSingularRow(word),
                FemalePluralRow = _fourthDeclensionService.GetPluralRow(word)
            };

            return result;
        }
    }
}
