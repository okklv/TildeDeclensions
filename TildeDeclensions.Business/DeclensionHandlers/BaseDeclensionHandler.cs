using TildeDeclensions.Business.DeclensionRules;
using TildeDeclensions.Business.DTOs;

namespace TildeDeclensions.Business.DeclensionServices
{
    public abstract class BaseDeclensionHandler : IDeclensionHandler
    {
        private IDeclensionHandler? _nextHandler;
        private readonly IEnumerable<IRule> _rules;

        protected BaseDeclensionHandler(IEnumerable<IRule> rules)
        {
            _rules = rules;
        }

        public IDeclensionHandler SetNext(IDeclensionHandler next)
        {
            _nextHandler = next;
            return next;
        }

        public InflectionData Handle(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentNullException(nameof(word));
            };
            if (_rules.All(rule => rule.Evaluate(word)))
            {
                return Process(word);
            }

            if (_nextHandler != null)
            {
                return _nextHandler.Handle(word);
            }
            throw new UndeterminedDeclensionException(word);
        }

        protected abstract InflectionData Process(string word);
    }
}
