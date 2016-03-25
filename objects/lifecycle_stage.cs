using System.Xml;

namespace PardotAPI
{
    public class lifecycle_stage : PardotAPI.@object
    {
        public string id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string is_locked { get; set; }

        public lifecycle_stage() { }
        public lifecycle_stage(XmlNode source) { loadObject(source);}
    }
}