using System.Collections.Generic;
using System.Linq;
using Translator.CommonData;

namespace Translator.SkyEng
{
    /// <summary>
    /// SkyEng dictionary clause.
    /// </summary>
    internal sealed class SEDictionaryClause
    {
        /// <summary>
        /// Text to translate.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The word translations.
        /// </summary>
        public IEnumerable<SEMeaningClause> Meanings { get; set; }


        /// <summary>
        /// Explicit conversion to common type.
        /// </summary>
        /// <param name="clause">Clause to convert.</param>
        public static explicit operator DictionaryClause(SEDictionaryClause clause)
        {
            // Instead one can use AutoMapper to convert types...

            return new DictionaryClause()
            {
                Transcription = clause.Meanings.FirstOrDefault()?.Transcription,
                Translations = 
                    clause.Meanings.Select(o => new TranslationClause() { Translation = o.Translation.Text }).ToList()
            };
        }
    }
}
