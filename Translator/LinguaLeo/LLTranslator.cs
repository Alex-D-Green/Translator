using System;
using System.Net.Http;
using System.Threading.Tasks;
using Translator.CommonData;

namespace Translator.LinguaLeo
{
    /// <summary>
    /// A translator by "http://lingualeo.com/".
    /// </summary>
    internal class LLTranslator: TranslatorBase
    {
        /// <summary>
        /// LinguaLeo web service base address.
        /// </summary>
        private const string baseAddress = "http://api.lingualeo.com/";


        /// <summary>
        /// Translate the word asynchronously.
        /// </summary>
        /// <param name="word">A word in English for translation to Russian.</param>
        /// <returns>A task that return translation result.</returns>
        /// <exception cref="System.Exception" />
        public async override Task<string> TranslateAsync(string word)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                // Send HTTP GET request with "word" parameter in query string
                HttpResponseMessage result = await client.GetAsync($"gettranslates?word={word}");

                if(result.IsSuccessStatusCode)
                { // Some answer is received

                    // Getting result data
                    LLDictionaryClause clause = await result.Content.ReadAsAsync<LLDictionaryClause>();

                    if(!String.IsNullOrEmpty(clause.Error_msg))
                        throw new Exception(clause.Error_msg); // Some kind of error

                    // Everything is Ok, so fetching result
                    return FormatClause(word, (DictionaryClause)clause);
                }
                else // An HTTP error occur
                    throw new Exception($"{result.StatusCode} - {result.ReasonPhrase}");
            }
        }
    }
}
