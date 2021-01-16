using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using static System.Console;

namespace  Dictionary
{/// <summary>
/// The <c>Mydictinary</c> class provaded methods for
/// add., delete,replace words, insert words in programm "dictionary"
/// </summary>
    public class MyDictinary
    {     
        
        /// <summary>
        /// the <c>DeliteWords</c> for delite words from dictionary
        /// </summary>
        /// <param name="Dictionary"></param>
        public  void DeliteWords(SortedDictionary<string, string> Dictionary)
        {
            WriteLine("введите слово которе нужно удалить");

            string ss = ReadLine();
            var qury = from s in Dictionary where s.Key == ss select s.Value;
            if (qury != null)
            {
                foreach (var p in qury)
                {

                    WriteLine($"'{ss}' имеет перевод:'{p}'");
                }

                Dictionary.Remove(ss);
                WriteLine($"'{ss}'-уже удалено из словоря/n");
            }
            else
            {
                WriteLine("нельзя удалить ");
            }

        }
        /// <summary>
        /// the <c>SeekWords</c> for search words in dictionary
        /// 
        /// </summary>
        /// <param name="Dictionary"></param>
        public void SeekWords(SortedDictionary<string, string> Dictionary)
        {
            BackgroundColor = ConsoleColor.DarkCyan;
            WriteLine("введите слово для поиска");


            string ss = ReadLine();
          //  WriteLine($"слово : '{ss}'  перевод-  ");

            try
            {
                WriteLine($"{ss}-перевод-{Dictionary[ss]} ");
               
            }
            catch (KeyNotFoundException)
            {
                WriteLine($"►{ss}◄ не найден");
                WriteLine("--Если Вам известен перевод\n" +
                        " войдите через F4 меню и добавте \n" +
                        " его в словарь или в исправте \n" +
                        " воспользовавшись F2 меню\n");
            }


        }

        public void AddWords(SortedDictionary<string, string> Dictionary)
        {
            BackgroundColor = ConsoleColor.DarkCyan;
            WriteLine("Введите словo ");
            string engl = ReadLine();
            string too = "";


            var qury = from s in Dictionary where s.Key == engl select s.Value;
            foreach (var p in qury)
            {
                WriteLine($"Слово '{engl}'уже записано в словаре");
                WriteLine($"вот его перевод -{p}");
                too = p;
                WriteLine("\nвыберите пункт меню");
            }

            if (too == "")
            {
                string ukr2 = "";
                metka:
                WriteLine("добавте перевод");
                string ukr1 = ReadLine();
                if (ukr1 != "")
                {

                    ukr2 += ukr1 + ",";
                    goto metka;
                }
                Dictionary.Add(engl, ukr2);
                WriteLine($"слово ►{engl}◄ добавлено в словарь\n");
            }
            ResetColor();
           

        }
        public void ReplaceWords(SortedDictionary<string, string> Dictionary)
        {
            BackgroundColor = ConsoleColor.DarkCyan;
            WriteLine("   Bведите слово для поиска\n " +
                      " кoторое Вы желаете удалить из словаря");


            string ss = ReadLine();
          

            try
            {
                WriteLine($"'{ss}' перевод '{Dictionary[ss]}' ");
                var qury = from s in Dictionary where s.Key == ss select s.Value;

                foreach (var p in qury)
                {
                    WriteLine($"'{p}' - будет удалeно'");
                }
            }
            catch (KeyNotFoundException)
            {
                WriteLine($"►{ss}◄ не найден");
                goto metka1;
            }
                    
            Dictionary.Remove(ss);
            WriteLine($"'{ss}'-удалено из словоря");
            WriteLine("Введите словo которое добовится в словарь ");
            string engl = ReadLine();
            string ukr2 = "";
            metka:
            WriteLine("добавте перевод");
            string ukr1 = ReadLine();
            if (ukr1 != "")
            {
                ukr2 += ukr1 + ",";
                goto metka;
            }
            Dictionary.Add(engl, ukr2);
         
            WriteLine($"слово ►{engl}◄ добавлено в словарь");
            metka1:
            WriteLine("\n");
        }
    }

}
