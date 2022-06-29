//jan Sewe
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ilo_Enkote_epiku
{
    public class Program
    {
        public static string filePath;
        public static string lines;
        public static byte version = 1;
        public static readonly string[] wordList =
        {
            "punc",
            "a",
            "akesi",
            "ala",
            "alasa",
            "ale",
            "anpa",
            "ante",
            "anu",
            "awen",
            "e",
            "en",
            "esun",
            "ijo",
            "ike",
            "ilo",
            "insa",
            "jaki",
            "jan",
            "jelo",
            "jo",
            "kala",
            "kalama",
            "kama",
            "kasi",
            "ken",
            "kepeken",
            "kili",
            "kin",
            "kiwen",
            "ko",
            "kon",
            "kule",
            "kulupu",
            "kute",
            "la",
            "lape",
            "laso",
            "lawa",
            "len",
            "lete",
            "li",
            "lili",
            "linja",
            "lipu",
            "loje",
            "lon",
            "luka",
            "lukin",
            "lupa",
            "ma",
            "mama",
            "mani",
            "meli",
            "mi",
            "mije",
            "moku",
            "moli",
            "monsi",
            "mu",
            "mun",
            "musi",
            "mute",
            "nanpa",
            "namako",
            "nasa",
            "nasin",
            "nena",
            "ni",
            "nimi",
            "noka",
            "o",
            "olin",
            "ona",
            "open",
            "pakala",
            "pali",
            "palisa",
            "pan",
            "pana",
            "pi",
            "pilin",
            "pimeja",
            "pini",
            "pipi",
            "poka",
            "poki",
            "pona",
            "pu",
            "sama",
            "seli",
            "selo",
            "seme",
            "sewi",
            "sijelo",
            "sike",
            "sin",
            "sina",
            "sinpin",
            "sitelen",
            "sona",
            "soweli",
            "suli",
            "suno",
            "supa",
            "suwi",
            "tan",
            "taso",
            "tawa",
            "telo",
            "tenpo",
            "toki",
            "tomo",
            "tu",
            "unpa",
            "uta",
            "utala",
            "walo",
            "wan",
            "waso",
            "wawa",
            "weka",
            "wile",
            "epiku",
            "jasima",
            "kijetesantakalu",
            "kipisi",
            "kokosila",
            "ku",
            "lanpan",
            "leko",
            "meso",
            "misikeke",
            "monsuta",
            "n",
            "soko",
            "tonsi",
            "apeja",
            "ete",
            "ewe",
            "isipin",
            "kamalawala",
            "kan",
            "kapesi",
            "ke",
            "kese",
            "kiki",
            "kulijo",
            "kuntu",
            "likujo",
            "linluwi",
            "loka",
            "majuna",
            "misa",
            "mulapisu",
            "oke",
            "pake",
            "pata",
            "peto",
            "po",
            "polinpin",
            "pomotolo",
            "powe",
            "samu",
            "san",
            "soto",
            "sutopatikuna",
            "taki",
            "teje",
            "umesu",
            "unu",
            "usawi",
            "wa",
            "waleja",
            "wasoweli",
            "ako",
            "alu",
            "awase",
            "enko",
            "itomi",
            "jaku",
            "jami",
            "je",
            "jonke",
            "jume",
            "kapa",
            "ki",
            "kisa",
            "konsi",
            "konwe",
            "kosan",
            "lenke",
            "lijokuku",
            "lo",
            "loku",
            "me",
            "melome",
            "mijomi",
            "molusa",
            "munsi",
            "natu",
            "nele",
            "nja",
            "nu",
            "nuwa",
            "okepuma",
            "omekapo",
            "omen",
            "oni",
            "owe",
            "pa",
            "pasila",
            "peta",
            "pika",
            "pipo",
            "poni",
            "puwa",
            "sikomo",
            "su",
            "take",
            "tokana",
            "wawajete",
            "wekama",
            "wi",
            "te",
            "to",
            "oko"
        };
        public static readonly char[] punctuation =
        {
            //Null
            'ÿ',
            //Null ASCII
            '\0',
            '.',
            Char.ConvertFromUtf32(9230)[0],
            Char.ConvertFromUtf32(9231)[0],
            '…',
            ' ',
            '\n',
            '\t',
            ',',
            '<',
            '>',
            '`',
            '~',
            '!',
            '@',
            '#',
            '$',
            '%',
            '^',
            '&',
            '*',
            '(',
            ')',
            '-',
            '=',
            '_',
            '+',
            ':',
            ';',
            '\'',
            '"',
            '[',
            ']',
            '{',
            '}',
            '/',
            '?',
            '|',
            '\\',
            '£',
            '€',
            '¥',
            '₩',
            'A',
            'E',
            'I',
            'J',
            'K',
            'L',
            'M',
            'N',
            'O',
            'P',
            'S',
            'T',
            'U',
            'W',
            'a',
            'e',
            'i',
            'j',
            'k',
            'l',
            'm',
            'n',
            'p',
            's',
            't',
            'u',
            'w'
        };
        public static Dictionary<string, byte> wordDict;
        public static Dictionary<byte, string> dictWord;
        public static Dictionary<char, byte> puncDict;
        public static Dictionary<byte, char> dictPunc;

        public static void Main(string[] args)
        {
            DictionarySetUp();
                    
            Console.WriteLine("kama pona e ilo Enkote epiku!");
            Console.WriteLine("lon ilo tenpo: " + version.ToString());
            if (args.Length == 0)
            {
                Console.WriteLine("o toki e lon lipu:");
                filePath = Console.ReadLine();
            }
            else
            {
                filePath = args[0];
            }

            if (filePath.EndsWith(".txt"))
            {
                Encode();
            } else if (filePath.EndsWith(".toki"))
            {
                Decode();
            } else
            {
                throw new FileNotFoundException(filePath + " li ala .toki anu .txt");
            }
        }

        public static void Encode()
        {
            try
            {
                lines = System.IO.File.ReadAllText(filePath);
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("o pana e namako nanpa wan pi lon lipu.");
                throw e;
            }


            lines = lines.Replace("...", "…");
            lines = lines.Replace('‘','\'');
            lines = lines.Replace('’', '\'');
            lines = lines.Replace('“', '\"');
            lines = lines.Replace('”', '\"');
            lines = lines.Replace('￥', '¥');

            lines = lines.Replace(".", " punc akesi ");
            lines = lines.Replace("…", " punc ale ");
            lines = lines.Replace("  ", " punc anpa ");
            lines = lines.Replace(Environment.NewLine, " punc ante ");
            lines = lines.Replace("\n", " punc ante ");
            lines = lines.Replace("\t", " punc anu ");
            lines = lines.Replace(",", " punc awen ");
            lines = lines.Replace("<", " punc e ");
            lines = lines.Replace(">", " punc en ");
            lines = lines.Replace("`", " punc esun ");
            lines = lines.Replace("~", " punc ijo ");
            lines = lines.Replace("!", " punc ike ");
            lines = lines.Replace("@", " punc ilo ");
            lines = lines.Replace("#", " punc insa ");
            lines = lines.Replace("$", " punc jaki ");
            lines = lines.Replace("%", " punc jan ");
            lines = lines.Replace("^", " punc jelo ");
            lines = lines.Replace("&", " punc jo ");
            lines = lines.Replace("*", " punc kala ");
            lines = lines.Replace("(", " punc kalama ");
            lines = lines.Replace(")", " punc kama ");
            lines = lines.Replace("-", " punc kasi ");
            lines = lines.Replace("=", " punc ken ");
            lines = lines.Replace("_", " punc kepeken ");
            lines = lines.Replace("+", " punc kili ");
            lines = lines.Replace(":", " punc kin ");
            lines = lines.Replace(";", " punc kiwen ");
            lines = lines.Replace("\'", " punc ko ");
            lines = lines.Replace("\"", " punc kon ");
            lines = lines.Replace("[", " punc kule ");
            lines = lines.Replace("]", " punc kulupu ");
            lines = lines.Replace("{", " punc kute ");
            lines = lines.Replace("}", " punc la ");
            lines = lines.Replace("/", " punc lape ");
            lines = lines.Replace("?", " punc laso ");
            lines = lines.Replace("|", " punc lawa ");
            lines = lines.Replace("\\", " punc len ");
            lines = lines.Replace("£", " punc lete ");
            lines = lines.Replace("€", " punc li ");
            lines = lines.Replace("¥", " punc lili ");
            lines = lines.Replace("₩", " punc linja ");

            string[] words = lines.Split(' ');


            List<byte> bytes = new List<byte>();
            bytes.Add(116);
            bytes.Add(111);
            bytes.Add(107);
            bytes.Add(105);
            bytes.Add(version);
            bytes.Add(0);
            foreach (string word in words)
            {
                if (String.IsNullOrWhiteSpace(word))
                    continue;
                if (Char.IsUpper(word[0]))
                {
                    bytes.Add(0);
                    bytes.Add(3);
                    bytes.Add(6);
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (i == 0)
                        {
                            bytes.Add(puncDict[word.ToUpper()[i]]);
                        } else
                        {
                            bytes.Add(puncDict[word.ToLower()[i]]);
                        }

                    }
                    bytes.Add(4);
                } else
                {
                    bytes.Add(wordDict[word]);

                }
            }

            File.WriteAllBytes(filePath.Replace(".txt",".toki"), bytes.ToArray());

        }

        public static void DictionarySetUp()
        {
            wordDict = wordList.ToDictionary(item => item, item => (byte)Array.IndexOf(wordList, item));
            dictWord = wordList.ToDictionary(item => (byte)Array.IndexOf(wordList, item), item => item);
            puncDict = punctuation.ToDictionary(item => item, item => (byte)Array.IndexOf(punctuation, item));
            dictPunc = punctuation.ToDictionary(item => (byte)Array.IndexOf(punctuation, item), item => item);
        }

        public static void Decode()
        {
            byte[] bytes;
            try
            {
                bytes = System.IO.File.ReadAllBytes(filePath);
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("o pana e namako nanpa wan pi lon lipu.");
                throw e;
            }

            if (bytes[0] == 116 && bytes[1] == 111 && bytes[2] == 107 && bytes[3] == 105)
            {
                if (bytes[4] > version)
                {
                    Console.WriteLine("lon tenpo ilo li sama ala e lon tenpo lipu");
                    Console.WriteLine("awen? (lon/ala)");
                    if (Console.ReadLine() == "ala")
                        throw new Exception("sina li awen ala.");
                }

                bool shiftHeld = false;
                bool shifted = false;
                int i = 7;
                lines = "";
                foreach (byte item in bytes)
                {
                    i--;
                    if (i > 0)
                        continue;
                    if (shifted || shiftHeld)
                    {
                        shifted = false;
                        if (item == 3)
                        {
                            shiftHeld = true;
                            continue;
                        } else if (item == 4)
                        {
                            shiftHeld = false;
                            continue;
                        } else
                        {
                            lines += dictPunc[item];

                        }

                    } else
                    {
                        if (item == 0)
                        {
                            shifted = true;
                            continue;
                        } else 
                        {
                            if (!(lines.EndsWith("\n") || lines.EndsWith("\"")) && i != 0)
                            {
                                lines += " ";
                            }

                            lines += dictWord[item];
                        }
                    }


                }


                File.WriteAllText(filePath.Replace(".toki", ".txt"), lines);
            } else
            {
                throw new FileNotFoundException(filePath + " li ala .toki");
            }

        }

    }
}