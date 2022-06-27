using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ilo_Enkote_epiku
{
    public class Program
    {
        public static string filePath;
        public static string lines;
        public static byte version = 0;
        public static readonly char[] delimiters = {' ', '\n', '\t' };
        public static readonly char[] punctuation = { ',', '(', ';', '.', ')', ':', '…', '/', '?', '&', '\'', '!', '\"', '[', '{', '@', ']', '}', '#', '-', '_', '=' };

        public static void Main(string[] args)
        {
            Encode(args);
        }

        public static void Encode(string[] args)
        {
            if (args.Length == 0)
            {
                while (filePath == null)
                {
                    Console.WriteLine("Enter filepath:");
                    filePath = Console.ReadLine();
                    try
                    {
                        lines = System.IO.File.ReadAllText(filePath);
                    }
                    catch (System.IO.FileNotFoundException)
                    { }
                }

            }
            else
            {
                filePath = args[0];
                try
                {
                    lines = System.IO.File.ReadAllText(filePath);
                }
                catch (System.IO.FileNotFoundException e)
                {
                    Console.WriteLine("You must supply a filepath as the first argument.");
                    throw e;
                }
            }

            List<bool> bits = new List<bool>();
            bool register = true;
            bool huffman = false;

            string[] wordsArray = lines.Split(delimiters);
            List<string> words = new List<string>(wordsArray);
            foreach (string wordSin in wordsArray)
            {

                if (punctuation.Any(x => wordSin.EndsWith(x)))
                {
                    switch (wordSin.Substring(wordSin.Length,1))
                    {
                        default:
                            break;
                        case ",":
                            break;
                    }
                }


            }





            List<byte> bytes = new List<byte>();
            // Magic Header: "toki"
            bytes.Add(116);
            bytes.Add(111);
            bytes.Add(107);
            bytes.Add(105);
            byte j = 0;
            if (register)
                j += 64;
            // IMPORTANT: If you are making a third-party editor for this filetype, DO NOT do the following line.
            // See the filetype schema for more information (README.md)
            j += 32;
            if (huffman)
                j += 16;
            bytes.Add(j);
            bytes.Add(version);
        }


    }
}