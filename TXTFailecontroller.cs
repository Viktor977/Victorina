using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using static System.Console;
namespace Dictionary
{
    class TXTFailecontroller
    {
        /// <summary>
        /// The <c>Records </c> is method for record in txt.file
        /// </summary>
        /// 
        ///The <param name="fileWrite">passes the file path to  </param> 
        /// <param name="D">name`s SortedDictionary</param>
        public  void Records(string fileWrite, SortedDictionary<string, string> D)
        {


            using (StreamWriter sw = new StreamWriter(fileWrite,
                true, Encoding.UTF8))
            {

                WriteLine("Введите слова ");
                string engl = ReadLine();
                string value = "";
                metka:
                WriteLine("добавте перевод");
                string ukr1 = ReadLine();
                if (ukr1 != "")
                {
                    value += ukr1 + ",";
                    goto metka;
                }
                try
                {
                    D.Add(engl, value);
                }
                catch (ArgumentException)
                {
                    WriteLine("Сдово уже есть в словоре");
                }
                sw.WriteLine(engl);
                sw.WriteLine(value);
                sw.Close();
                WriteLine($"  Запись слова '{engl}' и его перевод '{value}'\n" +
                    $"в текстовый файл {fileWrite} выполнено '");
            }

        }
        /// <summary>
        /// function for writing words from file to  SortedDictionary
        /// </summary>
        /// <param name="path"> passes the file path to read words and write them to
        /// SortedDictionary (MyEnglishSlovar)</param>
        /// <param name="D"> name Dictionare
        /// </param>
        public  void ReadersAndAdd(string path, SortedDictionary<string, string> D)
        {

            if (path != null)
            {

                using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
                {
                    string key;
                    string value;
                    while ((key = sr.ReadLine()) != null)//считывание слов из файла
                    {                                    //при запуске программы
                        value = sr.ReadLine();           //

                        D.Add(key, value);
                    }
                    sr.Close();
                }
            }


        }
    }
}
