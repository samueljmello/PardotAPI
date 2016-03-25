using System.Xml;

namespace PardotAPI
{
    public class visit : PardotAPI.@object
    {
        public string id { get; set; }
        public string visitor_id { get; set; }
        public string prospect_id { get; set; }
        public string visitor_page_view_count { get; set; }
        public string first_visitor_page_view_at { get; set; }
        public string last_visitor_page_view_at { get; set; }
        public string duration_in_seconds { get; set; }
        public string campaign_parameter { get; set; }
        public string medium_parameter { get; set; }
        public string source_parameter { get; set; }
        public string content_parameter { get; set; }
        public string term_parameter { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public visit() { }
        public visit(XmlNode source) { loadObject(source);}
    }
}