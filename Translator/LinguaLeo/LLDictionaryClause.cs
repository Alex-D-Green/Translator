using System.Collections.Generic;
using System.Linq;

using Translator.CommonData;

namespace Translator.LinguaLeo
{
    /// <summary>
    /// LinguaLeo dictionary clause.
    /// </summary>
    internal sealed class LLDictionaryClause
    {
        /// <summary>
        /// Error message if there one.
        /// </summary>
        public string Error_msg { get; set; }

        /// <summary>
        /// The word translations.
        /// </summary>
        public IEnumerable<LLTranslationClause> Translate { get; set; }

        /// <summary>
        /// The word transcription.
        /// </summary>
        public string Transcription { get; set; }


        /// <summary>
        /// Explicit conversion to common type.
        /// </summary>
        /// <param name="clause">Clause to convert.</param>
        public static explicit operator DictionaryClause(LLDictionaryClause clause)
        {
            // Instead one can use AutoMapper to convert types...

            return new DictionaryClause()
            {
                Transcription = clause.Transcription,
                Translations = clause.Translate.Select(o => (TranslationClause)o).ToList()
            };
        }
    }
}
