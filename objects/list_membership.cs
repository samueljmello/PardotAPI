using System.Xml;

namespace PardotAPI
{
    public class list_membership : PardotAPI.@object
    {
        public string id { get; set; }
        public string list_id { get; set; }
        public string prospect_id { get; set; }
        public string opted_out { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public list_membership() { }
        public list_membership(XmlNode source) { loadObject(source);}
    }
}