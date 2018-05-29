using System;
using System.Threading.Tasks;
using Translator.LinguaLeo;
using Translator.SkyEng;

namespace Translator
{
    /// <summary>
    /// A very simple console EN->RU dictionary.
    /// Copyright (c) 2018 Dyachenko A.S. das2010@bk.ru
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Used for fetching words in English.</param>
        public static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                Console.WriteLine("You got to enter one English word.");

                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }

            string word = args[0];

            foreach(var translator in new TranslatorBase[] { new LLTranslator(), new SETranslator() })
            {
                Console.WriteLine($"Translating \"{word}\" with \"{translator.TranslationBy}\", wait a second please...");
                Console.WriteLine();

                try
                {
                    // Getting translation task; 
                    // or you can use synchronous version like that: translator.Translate(word, 5000)
                    Task<string> task = translator.TranslateAsync(word);

                    if(!task.Wait(5000)) // Waiting for translation
                    {
                        Console.WriteLine("Sorry, timeout error!");
                        Console.WriteLine();
                    }
                    else
                        Console.WriteLine(task.Result);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Sorry, an error occur:");
                    Console.WriteLine(e.ToString());
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
