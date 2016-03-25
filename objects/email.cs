using System.Xml;

namespace PardotAPI
{
    public class email : PardotAPI.@object
    {
        public string id { get; set; }
        public string name { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public string created_at { get; set; }

        public email() { }
        public email(XmlNode source) { loadObject(source);}
    }
}