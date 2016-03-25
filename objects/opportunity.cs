using System.Xml;

namespace PardotAPI
{
    public class opportunity : PardotAPI.@object
    {
        public string id { get; set; }
        public string campaign_id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string probability { get; set; }
        public string type { get; set; }
        public string stage { get; set; }
        public string status { get; set; }
        public string closed_at { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public opportunity() { }
        public opportunity(XmlNode source) { loadObject(source);}
    }
}