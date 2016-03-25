using System.Xml;

namespace PardotAPI
{
    public class lifecycle_history : PardotAPI.@object
    {
        public string id { get; set; }
        public string prospect_id { get; set; }
        public string previous_stage_id { get; set; }
        public string next_stage_id { get; set; }
        public string seconds_elapsed { get; set; }
        public string created_at { get; set; }

        public lifecycle_history() { }
        public lifecycle_history(XmlNode source) { loadObject(source);}
    }
}