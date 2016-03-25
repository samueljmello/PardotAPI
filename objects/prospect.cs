using System;
using System.Reflection;
using System.Xml;

namespace PardotAPI
{
    public class prospect : PardotAPI.@object
    {
        public string id { get; set; }
        public string campaign_id { get; set; }
        public string salutation { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string company { get; set; }
        public string website { get; set; }
        public string job_title { get; set; }
        public string department { get; set; }
        public string country { get; set; }
        public string address_one { get; set; }
        public string address_two { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string territory { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string source { get; set; }
        public string annual_revenue { get; set; }
        public string employees { get; set; }
        public string industry { get; set; }
        public string years_in_business { get; set; }
        public string comments { get; set; }
        public string notes { get; set; }
        public string score { get; set; }
        public string grade { get; set; }
        public string last_activity_at { get; set; }
        public string recent_interaction { get; set; }
        public string crm_lead_fid { get; set; }
        public string crm_contact_fid { get; set; }
        public string crm_owner_fid { get; set; }
        public string crm_account_fid { get; set; }
        public string crm_last_sync { get; set; }
        public string crm_url { get; set; }
        public string is_do_not_email { get; set; }
        public string is_do_not_call { get; set; }
        public string opted_out { get; set; }
        public string is_reviewed { get; set; }
        public string is_starred { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public prospect() { }
        public prospect(XmlNode thisSource) { loadObject(thisSource); }
    }
}