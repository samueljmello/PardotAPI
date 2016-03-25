using System.Xml;

namespace PardotAPI
{
    public class tag_object : PardotAPI.@object
    {
        public string id { get; set; }
        public string tag_id { get; set; }
        public string type { get; set; }
        public string object_id { get; set; }
        public string created_at { get; set; }

        public tag_object() { }
        public tag_object(XmlNode source) { loadObject(source);}
    }
}