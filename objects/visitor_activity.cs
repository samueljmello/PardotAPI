using System.Xml;

namespace PardotAPI
{
    public class visitor_activity : PardotAPI.@object
    {
        public string id { get; set; }
        public string prospect_id { get; set; }
        public string visitor_id { get; set; }
        public string type { get; set; }
        public string type_name { get; set; }
        public string details { get; set; }
        public string email_id { get; set; }
        public string form_id { get; set; }
        public string form_handler_id { get; set; }
        public string site_search_query_id { get; set; }
        public string landing_page_id { get; set; }
        public string paid_search_id_id { get; set; }
        public string multivariate_test_variation_id { get; set; }
        public string visitor_page_view_id { get; set; }
        public string file_id { get; set; }
        public string created_at { get; set; }

        public visitor_activity() { }
        public visitor_activity(XmlNode source) { loadObject(source);}
    }
}