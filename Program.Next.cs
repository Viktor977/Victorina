using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using static System.Console;

namespace Dictionary
{
    partial class Program
    {
        static SimpleSelector selector;

        private static string[] items1 = new string[] {

            "Англiйсько-Український словник",
            "Українсько-Англiйський словник",
            "Показати весь словарь",
            "Записати слова в файл ",
            "Завершити роботу программи",

        };

        /// <summary>
        /// The Progrm Submenu
        /// </summary>
        /// <param name="myEnglishSlovar1"> passing from main SortedDictionary-MyEnglish
        /// Slovar</param>
        private static void menuEng(SortedDictionary<string, string> myEnglishSlovar1)
        {
            var EnglishDictionary = new MyDictinary();
            while (true)
            {
                System.Threading.Thread.Sleep(0);
                if (!KeyAvailable)
                    continue;

                var choise = ReadKey(true);
                if (choise.Modifiers != 0)
                    continue;
                switch (choise.Key)
                {

                    case ConsoleKey.F1:
                        BackgroundColor = ConsoleColor.DarkCyan;
                        selector.Erase2();
                        WriteLine("Пунк меню '►Найти слово◄'");
                        EnglishDictionary.SeekWords(myEnglishSlovar1);
                        WriteLine("Выберите следующий пункт\n");
                        selector.Erase2();

                        break;
                    case ConsoleKey.F2:

                        BackgroundColor = ConsoleColor.DarkCyan;
                        selector.Erase2();
                        WriteLine("Пунк меню '►Заменить слово◄'");
                        EnglishDictionary.ReplaceWords(myEnglishSlovar1);
                        WriteLine("Выберите следующий путкт");
                        selector.Erase2();

                        break;
                    case ConsoleKey.F3:
                        BackgroundColor = ConsoleColor.DarkCyan;
                        selector.Erase2();
                        WriteLine("Пунк меню '►удалить слово◄'");
                        EnglishDictionary.DeliteWords(myEnglishSlovar1);
                        WriteLine("Выберите следующий путкт");
                        selector.Erase2();
                        break;

                    case ConsoleKey.F4:
                        BackgroundColor = ConsoleColor.DarkCyan;
                        selector.Erase2();
                        WriteLine("Пунк меню '►добавить слово◄'");
                        EnglishDictionary.AddWords(myEnglishSlovar1);
                        WriteLine("Выберите следующий путкт");
                        selector.Erase2();

                        break;
                    case ConsoleKey.Escape:
                        goto metka;

                }

            }
            metka:
            BackgroundColor = ConsoleColor.DarkCyan;
            selector.Erase2();
            WriteLine("\n  Вы вышли из словоря");

        }


    }

}
