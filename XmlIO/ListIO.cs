using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

//simplifies IO to xml
namespace XmlIO
{
    //List<T> treatment
    public class ListIO
    {
        //Writes a list to an xml file
        public static void WriteList<T>(string path, List<T> list)
        {
            using (var Writer = new FileStream(path, FileMode.Create))
            {
                XmlSerializer Serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("product_list"));
                Serializer.Serialize(Writer, list);
                Writer.Close();
            }
        }

        //Reads list from an xml file
        public static List<T> ReadList<T>(string path)
        {
            List<T> list;
            using (var Reader = new StreamReader(path))
            {
                XmlSerializer Deserializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("product_list"));
                list = (List<T>)Deserializer.Deserialize(Reader);
            }
            return list;
        }
    }
}
