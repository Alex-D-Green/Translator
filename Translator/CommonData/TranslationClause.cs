namespace Translator.CommonData
{
    /// <summary>
    /// One of the word translation.
    /// </summary>
    internal class TranslationClause
    {
        /// <summary>
        /// Translation.
        /// </summary>
        public string Translation { get; set; }

        /// <summary>
        /// Type of the word.
        /// </summary>
        public WordType Type { get; set; }

        /// <summary>
        /// The word transcription.
        /// </summary>
        public string Transcription { get; set; }
    }
}
