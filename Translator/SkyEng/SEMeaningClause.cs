using Translator.CommonData;

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

        /// <summary>
        /// Word type.
        /// </summary>
        /// <seealso cref="Translator.SkyEng.SEMeaningClause.GetWordType"/>
        public string PartOfSpeechCode { get; set; }


        /// <summary>
        /// Convert <see cref="Translator.SkyEng.SEMeaningClause.PartOfSpeechCode"/> into common format.
        /// </summary>
        /// <returns>Type of the word.</returns>
        public WordType GetWordType()
        {
            switch(PartOfSpeechCode)
            {
                case "n": return WordType.Noun;
                case "v": return WordType.Verb;
                case "prp": return WordType.Preposition;
                case "r": return WordType.Adverb;
                case "j": return WordType.Adjective;

                default: return WordType.Unknown;
            }
        }
    }
}
