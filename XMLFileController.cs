using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Console;

namespace Dictionary
{ 
    /// <summary>
    ///The <c> XMLFileController</c> for save and load  Data-Dictionary xml files;
    /// </summary>
    class XMLFileController
    {
        public void SaveEnglishUkranian(string file, SortedDictionary<string, string> dictionary)
        {
            XmlTextWriter writer = null;
             writer = new XmlTextWriter(file, Encoding.Unicode);
             writer.Formatting = Formatting.Indented;
            try
            {
                writer.WriteStartElement("EnglishUkranian");
                foreach (var p in dictionary)
                {
                    writer.WriteStartElement("Dictionary");
                    writer.WriteElementString("word", p.Key);
                    writer.WriteElementString("translate", p.Value);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        public void SaveUkranianEnglish(string file, SortedDictionary<string, string> dictionary)
        {
            XmlTextWriter writer = null;
            writer = new XmlTextWriter(file, Encoding.Unicode);
            writer.Formatting = Formatting.Indented;
            try
            {
                writer.WriteStartElement("EnglishUkranian");
                foreach (var p in dictionary)
                {
                    writer.WriteStartElement("Dictionary");
                    writer.WriteElementString("word", p.Key);
                    writer.WriteElementString("translate", p.Value);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }


        //-----------------------------------------------
        public void Load(string file, SortedDictionary<string, string> dictionary)
        {
            if (!File.Exists(file)) return;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            using (XmlReader reader = XmlReader.Create(file, settings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "Dictionary")
                        {

                            reader.ReadStartElement("Dictionary");
                            string key = reader.ReadElementContentAsString();

                            string value = reader.ReadElementContentAsString();
                            dictionary.Add(key, value);

                        }
                    }
                }
            }
        }
           
    }
}
