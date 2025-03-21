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

        /// <summary>
        /// Sets the next handler in the chain of responsibility.
        /// This allows for continous processing if the current handler rules are not fulfilled
        /// </summary>
        public IDeclensionHandler SetNext(IDeclensionHandler next)
        {
            _nextHandler = next;
            return next;
        }

        /// <summary>
        /// Evaluates the rules of handlers
        /// Proccesses the word, when all the rules are fulfilled
        /// </summary>
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

        /// <summary>
        /// Processes the word and returns all the inflections depending on declension
        /// </summary>
        protected abstract InflectionData Process(string word);
    }
}
