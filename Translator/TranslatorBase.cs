using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Translator.CommonData;

namespace Translator
{
    /// <summary>
    /// An abstract translator.
    /// </summary>
    internal abstract class TranslatorBase
    {
        /// <summary>
        /// Translation service name.
        /// </summary>
        public abstract string TranslationBy { get; }


        /// <summary>
        /// Translate the word asynchronously.
        /// </summary>
        /// <param name="word">A word in English for translation to Russian.</param>
        /// <returns>A task that return translation result.</returns>
        public abstract Task<string> TranslateAsync(string word);

        /// <summary>
        /// Translate the word synchronously.
        /// </summary>
        /// <param name="word">A word in English for translation to Russian.</param>
        /// <param name="timeout">Operation timeout.</param>
        /// <returns>A task that return translation result.</returns>
        public string Translate(string word, int timeout = -1)
        {
            var task = TranslateAsync(word);
            task.Wait(timeout);

            return task.Result;
        }

        /// <summary>
        /// Format translation output.
        /// </summary>
        /// <param name="word">A word for translation.</param>
        /// <param name="clause">Relevant dictionary clause.</param>
        /// <returns>Text output.</returns>
        protected virtual string FormatClause(string word, DictionaryClause clause)
        {
            var ret = new StringBuilder("");
            ret.AppendFormat("{0}:{1}", word, Environment.NewLine);

            int i = 0;
            foreach(string translate in clause.Translations.Select(o => o.Translation).Distinct())
                ret.AppendFormat("  {0}: {1};{2}", ++i, translate, Environment.NewLine);

            return ret.ToString();
        }
    }
}
