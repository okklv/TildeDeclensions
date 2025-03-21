using System.Data;
using TildeDeclensions.Business.DeclensionRules;
using TildeDeclensions.Business.DTOs;

namespace TildeDeclensions.Business.DeclensionServices
{
    public class FirstDeclensionHandler : BaseDeclensionHandler, INounDeclensionService
    {
        
        public FirstDeclensionHandler(IEnumerable<IRule> rules) : base(rules)
        {

        }
        protected override InflectionData Process(string word)
        {
            var result = new MaleInflectionData
            {
                MaleSingularRow = GetSingularRow(word),
                MalePluralRow = GetPluralRow(word)
            };
            return result;
        }

        public InflectionRow GetSingularRow(string word)
        {
            return new InflectionRow(
                nominative: GetSingularNominative(word),
                genitive: GetSingularGenitive(word),
                dative: GetSingularDative(word),
                accusative: GetSingularAccusative(word),
                instrumental: GetSingularInstrumental(word),
                locative: GetSingularLocative(word),
                vocative: GetSingularVocative(word));
        }

        public InflectionRow GetPluralRow(string word)
        {
            return new InflectionRow(
                nominative: GetPluralNominative(word),
                genitive: GetPluralGenitive(word),
                dative: GetPluralDative(word),
                accusative: GetPluralAccusative(word),
                instrumental: GetPluralInstrumental(word),
                locative: GetPluralLocative(word),
                vocative: GetPluralVocative(word));
        }

        private const string NOMINATIVE_SINGULAR_SUFFIX = "s";

        /// <summary>
        /// Returns the singular nominative form (base form with '-s')
        /// </summary>
        private string GetSingularNominative(string word)
        {
            return word.Substring(0, word.Length - 1) + NOMINATIVE_SINGULAR_SUFFIX;
        }

        private const string NOMINATIVE_PLURAL_SUFFIX = "i";

        /// <summary>
        /// Returns the plural nominative form (replace last letter with 'i')
        /// </summary>
        private string GetPluralNominative(string word)
        {
            return word.Substring(0, word.Length - 1) + NOMINATIVE_PLURAL_SUFFIX;
        }


        private const string GENITIVE_SINGULAR_SUFFIX = "a";
        /// <summary>
        /// Returns the singular genitive form (replace last letter with 'a')
        /// </summary>
        private string GetSingularGenitive(string word)
        {
            return word.Substring(0, word.Length - 1) + GENITIVE_SINGULAR_SUFFIX;
        }

        private const string GENITIVE_PLURAL_SUFFIX = "u";

        /// <summary>
        /// Returns the plural genitive form (replace last letter with 'u')
        /// </summary>
        private string GetPluralGenitive(string word)
        {
            return word.Substring(0, word.Length - 1) + GENITIVE_PLURAL_SUFFIX;
        }


        private const string DATIVE_SINGULAR_SUFFIX = "am";
        /// <summary>
        /// Returns the singular dative form (replace last letter with 'am')
        /// </summary>
        private string GetSingularDative(string word)
        {
            return word.Substring(0, word.Length - 1) + DATIVE_SINGULAR_SUFFIX;
        }

        private const string DATIVE_PLURAL_SUFFIX = "iem";
        /// <summary>
        /// Returns the plural dative form (replace last letter with 'iem')
        /// </summary>
        private string GetPluralDative(string word)
        {
            return word.Substring(0, word.Length - 1) + DATIVE_PLURAL_SUFFIX;
        }

        private const string ACCUSATIVE_SINGULAR_SUFFIX = "u";
        /// <summary>
        /// Returns the singular accusative form (replace last letter with 'u')
        /// </summary>
        private string GetSingularAccusative(string word)
        {
            return word.Substring(0, word.Length - 1) + ACCUSATIVE_SINGULAR_SUFFIX;
        }

        private const string ACCUSATIVE_PLURAL_SUFFIX = "us";
        /// <summary>
        /// Returns the plural accusative form (replace last letter with 'us')
        /// </summary>
        private string GetPluralAccusative(string word)
        {
            return word.Substring(0, word.Length - 1) + ACCUSATIVE_PLURAL_SUFFIX;
        }

        private const string INSTRUMENTAL_PREFIX = "ar ";
        private const string INSTRUMENTAL_SINGULAR_SUFFIX = "u";
        /// <summary>
        /// Returns the singular instrumental form (replace last letter with 'u' and adds 'ar ' as prefix)
        /// </summary>
        private string GetSingularInstrumental(string word)
        {
            return INSTRUMENTAL_PREFIX + word.Substring(0, word.Length - 1) + INSTRUMENTAL_SINGULAR_SUFFIX;
        }

        private const string INSTRUMENTAL_PLURAL_SUFFIX = "iem";
        /// <summary>
        /// Returns the plural instrumental form (replace last letter with 'iem' and adds 'ar ' as prefix)
        /// </summary>
        private string GetPluralInstrumental(string word)
        {
            return INSTRUMENTAL_PREFIX + word.Substring(0, word.Length - 1) + INSTRUMENTAL_PLURAL_SUFFIX;
        }

        private const string LOCATIVE_SINGULAR_SUFFIX = "ā";
        /// <summary>
        /// Returns the singular locative form (replace last letter with 'ā')
        /// </summary>
        private string GetSingularLocative(string word)
        {
            return word.Substring(0, word.Length - 1) + LOCATIVE_SINGULAR_SUFFIX;
        }

        private const string LOCATIVE_PLURAL_SUFFIX = "os";
        /// <summary>
        /// Returns the plural locative form (replace last letter with 'os')
        /// </summary>
        private string GetPluralLocative(string word)
        {
            return word.Substring(0, word.Length - 1) + LOCATIVE_PLURAL_SUFFIX;
        }

        private const string VOCATIVE_SINGULAR_SUFFIX = "!";
        /// <summary>
        /// Returns the singular vocative form (adds exclamation mark)
        /// </summary>
        private string GetSingularVocative(string word)
        {
            return word + VOCATIVE_SINGULAR_SUFFIX;
        }

        private const string VOCATIVE_PLURAL_SUFFIX = "i!";

        /// <summary>
        /// Returns the plural vocative form (replace last letter with 'i')
        /// </summary>
        private string GetPluralVocative(string word)
        {
            return word.Substring(0, word.Length - 1) + VOCATIVE_PLURAL_SUFFIX;
        }
    }
}
