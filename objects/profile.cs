using System.Xml;

namespace PardotAPI
{
    public class profile : PardotAPI.@object
    {
        public string id { get; set; }
        public string name { get; set; }

        public profile() { }
        public profile(XmlNode source) { loadObject(source);}
    }
}