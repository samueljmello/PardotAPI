using System.Xml;

namespace PardotAPI
{
    public class user : PardotAPI.@object
    {
        public string id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string job_title { get; set; }
        public string role { get; set; }
        public string account { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public user() { }
        public user(XmlNode source) { loadObject(source);}
    }
}