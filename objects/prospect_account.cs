using System.Xml;

namespace PardotAPI
{
    public class prospect_account : PardotAPI.@object
    {
        public string id { get; set; }
        public string name { get; set; }

        public prospect_account() { }
        public prospect_account(XmlNode source) { loadObject(source);}
    }
}
 