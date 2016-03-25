using System.Xml;

namespace PardotAPI
{
    public class campaign : PardotAPI.@object
    {
        public string id { get; set; }
        public string name { get; set; }
        public string cost { get; set; }

        public campaign() { }
        public campaign(XmlNode source) { loadObject(source); }
    }
}