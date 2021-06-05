using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CarPark.Serializers
{
    static class Serializer<T>
    {
        public static void Serialize(string path, List<T> list)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, list);
            }
        }
    }
}
