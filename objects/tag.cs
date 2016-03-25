using System.Xml;

namespace PardotAPI
{
    public class tag : PardotAPI.@object
    {
        public string id { get; set; }
        public string name { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public tag() { }
        public tag(XmlNode source) { loadObject(source);}
    }
}