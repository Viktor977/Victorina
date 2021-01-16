using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using static System.Console;

namespace Dictionary
{
    /// <summary>
    /// Нельзя удалить слово если это его последний перевод,не сделано....
    /// </summary>
    partial class Program
    {
        static void Main(string[] args)
        {

            Settings.SetConsoleParam();
            Settings.Head();
            Settings.MenuContent();


            BackgroundColor = ConsoleColor.DarkCyan;
            Write("\nВиберiть роздiл: ");
            ResetColor();

            selector = new SimpleSelector(CursorLeft,
            CursorTop, 36, items1);
            selector.Focus();
            string text = selector.Text;
            BackgroundColor = ConsoleColor.DarkCyan;
            WriteLine("\nВи обрали :\t" + text);


            // ReSharper disable once InvalidXmlDocComment
            /// The <summary>
            /// <c> MyEnglishSlovar</c>for work with English-Ukraine dictionary
            ///<c>MyUkrSlovar</c> for work with Ukrain-English dictionary
            /// </summary>

            var MyEnglishSlovar = new SortedDictionary<string, string>();
            var MyUkrSlovar = new SortedDictionary<string, string>();

            string FilePath = "English.txt";
            string FilePathUkr = "Ukr.txt";
            TXTFailecontroller txt = new TXTFailecontroller();
            txt.ReadersAndAdd(FilePath, MyEnglishSlovar);
            txt.ReadersAndAdd(FilePathUkr, MyUkrSlovar);
            bool flag = true;
            while (flag)
            {

                selector.Focus1();
                string text1 = selector.Text;
                BackgroundColor = ConsoleColor.DarkCyan;
                WriteLine("\nВи обрали :\t" + text1 + "\n");
                ResetColor();

                switch (text1)
                {

                    case "Англiйсько-Український словник":
                        BackgroundColor = ConsoleColor.DarkCyan;
                        selector.Erase1();
                        WriteLine("Выберите пункт меню\n");
                        menuEng(MyEnglishSlovar);
                        ResetColor();
                        break;

                    case "Українсько-Англiйський словник":
                        BackgroundColor = ConsoleColor.DarkCyan;
                        selector.Erase1();
                        WriteLine("Выберите пункт меню\n");
                        menuEng(MyEnglishSlovar);
                        ResetColor();
                        break;

                    case "Показати весь словарь":
                        BackgroundColor = ConsoleColor.DarkCyan;
                        selector.Erase1();
                        foreach (var f in MyEnglishSlovar)
                        {
                            WriteLine($"{f.Key}----{f.Value}");
                        }

                        ResetColor();
                        break;

                    case "Записати слова в файл ":
                        string path = "Ukr.txt";
                       
                        BackgroundColor = ConsoleColor.DarkCyan;
                        selector.Erase1();
                        txt. Records(path, MyEnglishSlovar);

                       //пример считывания словаря из XML файла
                          //string file = ".\\EnglUkr.xml";

                          //XMLFileController xml = new XMLFileController();
                          //xml.SaveEnglishUkranian(file,MyEnglishSlovar);
                          //var TD = new SortedDictionary<string, string>();
                          //xml.Load(file,TD);
                          //foreach (var i in TD)
                          //{
                          //    WriteLine($"{(i.Key)}---{i.Value}") ;
                          //}

                        ResetColor();
                        break;

                    case "Завершити роботу программи":
                        flag = false;
                        
                        break;
                }

            }
           
            ReadKey();
        }

    }
}
