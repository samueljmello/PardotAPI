using System.Xml;

namespace PardotAPI
{
    public class dynamic_content : PardotAPI.@object
    {
        public string id { get; set; }
        public string name { get; set; }
        public string embedCode { get; set; }
        public string embedUrl { get; set; }
        public string baseContent { get; set; }
        public string basedOn { get; set; }
        public string variation { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public dynamic_content() { }
        public dynamic_content(XmlNode source) { loadObject(source); }
    }
}