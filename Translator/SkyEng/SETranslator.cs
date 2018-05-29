using System;
using System.Net.Http;
using System.Threading.Tasks;
using Translator.CommonData;

namespace Translator.SkyEng
{
    /// <summary>
    /// A translator by "http://skyeng.ru/".
    /// </summary>
    internal sealed class SETranslator: TranslatorBase
    {
        /// <summary>
        /// LinguaLeo web service base address.
        /// </summary>
        private const string baseAddress = "https://dictionary.skyeng.ru/";


        /// <summary>
        /// Translation service name.
        /// </summary>
        public override string TranslationBy => "SkyEng";


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

                // Send HTTP GET request with "search" and "_format" parameters in query string
                HttpResponseMessage result = 
                    await client.GetAsync($"api/public/v1/words/search?_format=json&search={word}");

                if(result.IsSuccessStatusCode)
                { // Some answer is received

                    // Getting result data
                    SEDictionaryClause[] clause = await result.Content.ReadAsAsync<SEDictionaryClause[]>();

                    if(clause.Length == 0)
                        throw new Exception("Nothing was found.");

                    // Everything is Ok, so fetching result
                    return FormatClause(word, (DictionaryClause)clause[0]);
                }
                else // An HTTP error occur
                    throw new Exception($"{result.StatusCode} - {result.ReasonPhrase}");
            }
        }
    }
}
