using System.Xml;

namespace PardotAPI
{
    public class visitor_page_view : PardotAPI.@object
    {
        public string id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string created_at { get; set; }

        public visitor_page_view() { }
        public visitor_page_view(XmlNode source) { loadObject(source);}
    }
}