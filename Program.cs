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
        public static readonly string[] words =
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
            //REPLACE kulu >> kulupu
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
            //REPLACE oko & lokon with lukin
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
            //REPLAECE jalin >> noka
            "noka",
            "o",
            "olin",
            //REPLACE: i & iki & ipi with ona
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
            //REPLACE ten with tenpo
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
            "kin",
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
            //REPLACEMENT neja >> po
            "po",
            "polinpin",
            "pomotolo",
            "powe",
            "samu",
            //REPLACEMENT tuli >> san
            "san",
            "soto",
            "sutopatikuna",
            "taki",
            "teje",
            //REPLACEMENT te & to >> "
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
            //REPLACe aka & eki with natu
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
            "wi"
        };
        public static readonly char[] punctuation =
        {
            //Null literal (only if error occurs):
            '\0',
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
            'A',
            'B',
            'C',
            'D',
            'E',
            'F',
            'G',
            'H',
            'I',
            'J',
            'K',
            'L',
            'M',
            'N',
            'O',
            'P',
            'Q',
            'R',
            'S',
            'T',
            'U',
            'V',
            'W',
            'X',
            'Y',
            'Z'
        };

        public static void Main(string[] args)
        {
            Console.WriteLine("kama pona e ilo Enkote epiku!");
            Console.WriteLine("lon ilo tenpo: " + version.ToString());
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

            List<byte> bytes = new List<byte>();
            bytes.Add(116);
            bytes.Add(111);
            bytes.Add(107);
            bytes.Add(105);
            bytes.Add(version);
            bytes.Add(0);
        }


    }
}