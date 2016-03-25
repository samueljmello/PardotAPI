using System.Xml;

namespace PardotAPI
{
    public class profile_criteria : PardotAPI.@object
    {
        public string id { get; set; }
        public string name { get; set; }
        public string matches { get; set; }

        public profile_criteria() { }
        public profile_criteria(XmlNode source) { loadObject(source);}
    }
}