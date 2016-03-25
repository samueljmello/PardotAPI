using System.Xml;

namespace PardotAPI
{
    public class list : PardotAPI.@object
    {
        public string id { get; set; }
        public string name { get; set; }
        public string is_public { get; set; }
        public bool is_dynamic { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string is_crm_visible { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public list() { }
        public list(XmlNode source) { loadObject(source);}
    }
}