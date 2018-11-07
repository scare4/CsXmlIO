using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace XmlIO
{
    public class ObjectIO
    {
        public static void WriteObject<T>(string path, T Object, string root)
        {
            using (var Writer = new FileStream(path, FileMode.Create))
            {
                XmlSerializer Serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(root));
                Serializer.Serialize(Writer, Object);
            }
        }
        
        public static object ReadObject(string path, string root)
        {
            object Object;
            using (var Reader = new StreamReader(path))
            {
                XmlSerializer Deserializer = new XmlSerializer(typeof(object), new XmlRootAttribute(root));
                Object = Deserializer.Deserialize(Reader);
            }
            return Object;
        }
    }
}
