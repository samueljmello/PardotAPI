using System.Xml;

namespace PardotAPI
{
    public class custom_redirect : PardotAPI.@object
    {
        public string id { get; set; }
        public string name { get; set; }
        public string Url { get; set; }
        public string destination { get; set; }
        public string campaign { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public custom_redirect() { }
        public custom_redirect(XmlNode source) { loadObject(source); }
    }
}