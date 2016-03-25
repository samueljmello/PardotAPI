using System.Xml;

namespace PardotAPI
{
    public class identified_company : PardotAPI.@object
    {
        public string id { get; set; }
        public string name { get; set; }
        public string street_address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string email { get; set; }

        public identified_company() { }
        public identified_company(XmlNode source) { loadObject(source);}
    }
}