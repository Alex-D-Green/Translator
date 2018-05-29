namespace Translator.CommonData
{
    /// <summary>
    /// Word type.
    /// </summary>
    internal enum WordType: byte
    {
        Unknown,
        Noun,
        Adjective,
        Adverb,
        Verb,
        Preposition
    }


    /// <summary>
    /// Extensions for <see cref="Translator.CommonData.WordType"/>.
    /// </summary>
    internal static class WordTypeExtension
    {
        /// <summary>
        /// Get text description in a short form.
        /// </summary>
        /// <param name="type">Type of the word.</param>
        /// <returns>Text description in a short form.</returns>
        public static string ToShortFormString(this WordType type)
        {
            switch(type)
            {
                case WordType.Unknown: return "-";
                case WordType.Noun: return "сущ";
                case WordType.Adjective: return "прил";
                case WordType.Adverb: return "нар";
                case WordType.Verb: return "гл";
                case WordType.Preposition: return "предл";

                default: return type.ToString();
            }
        }
    }
}
