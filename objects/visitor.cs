using System.Xml;

namespace PardotAPI
{
    public class visitor : PardotAPI.@object
    {
        public string id { get; set; }
        public string page_view_count { get; set; }
        public string ip_address { get; set; }
        public string hostname { get; set; }
        public string campaign_parameter { get; set; }
        public string medium_parameter { get; set; }
        public string source_parameter { get; set; }
        public string content_parameter { get; set; }
        public string term_parameter { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public visitor() { }
        public visitor(XmlNode source) { loadObject(source);}
    }
}