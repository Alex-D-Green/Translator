using Translator.CommonData;

namespace Translator.LinguaLeo
{
    /// <summary>
    /// LinguaLeo one of the word translation.
    /// </summary>
    internal sealed class LLTranslationClause
    {
        /// <summary>
        /// A translation.
        /// </summary>
        public string Value { get; set; }


        /// <summary>
        /// Explicit conversion to common type.
        /// </summary>
        /// <param name="clause">Clause to convert.</param>
        public static explicit operator TranslationClause(LLTranslationClause clause)
        {
            return new TranslationClause() { Translation = clause.Value };
        }
    }
}
