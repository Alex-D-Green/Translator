namespace Translator.SkyEng
{
    /// <summary>
    /// SkyEng one of the word meaning.
    /// </summary>
    internal sealed class SEMeaningClause
    {
        /// <summary>
        /// The word translation.
        /// </summary>
        public SETranslationClause Translation { get; set; }

        /// <summary>
        /// The word transcription.
        /// </summary>
        public string Transcription { get; set; }
    }
}
