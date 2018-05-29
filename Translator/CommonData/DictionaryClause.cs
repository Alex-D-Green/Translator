using System.Collections.Generic;

namespace Translator.CommonData
{
    /// <summary>
    /// Dictionary clause.
    /// </summary>
    internal class DictionaryClause
    {
        /// <summary>
        /// The word translations.
        /// </summary>
        public IEnumerable<TranslationClause> Translations { get; set; }
    }
}
