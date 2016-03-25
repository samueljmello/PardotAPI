using System.Xml;

namespace PardotAPI
{
    public class visitor_referrer : PardotAPI.@object
    {
        public int id { get; set; }
        public string referrer { get; set; }
        public string vendor { get; set; }
        public string type { get; set; }
        public string query { get; set; }

        public visitor_referrer() { }
        public visitor_referrer(XmlNode source) { loadObject(source);}
    }
}