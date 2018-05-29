using System;
using System.Threading.Tasks;

using Translator.LinguaLeo;

namespace Translator
{
    /// <summary>
    /// A very simple console EN->RU translator.
    /// Copyright (c) 2018 Dyachenko A.S. das2010@bk.ru
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Used for fetching words in English.</param>
        /// <returns>App return code.</returns>
        public static int Main(string[] args)
        {
            // Creating one of the translators
            TranslatorBase translator = new LLTranslator();

            if(args.Length != 1)
            {
                Console.WriteLine("You got to enter one English word.");

                Console.WriteLine("Press any key...");
                Console.ReadKey();

                return -1;
            }

            int ret = 0;
            string word = args[0];
            Console.WriteLine($"Translating \"{word}\", wait a second please...");
            Console.WriteLine();

            try
            {
                // Getting translation task; 
                // or you can use synchronous version like that: translator.Translate(word, 5000)
                Task<string> task = translator.TranslateAsync(word);

                if(!task.Wait(5000)) // Waiting for translation
                {
                    Console.WriteLine("Sorry, timeout error!");
                    ret = -100;
                }
                else
                    Console.WriteLine(task.Result);
            }
            catch(Exception e)
            {
                Console.WriteLine("Sorry, an error occur:");
                Console.WriteLine(e.ToString());

                ret = -200;
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();

            return ret;
        }
    }
}
