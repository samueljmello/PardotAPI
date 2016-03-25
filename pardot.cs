using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace PardotAPI
{ 

    // -------------------------------------------------------------
    // --------- Main class object - handles all calls -------------
    // -------------------------------------------------------------

    public class pardot
    {

        // ----------------------------------
        // --------- properties -------------
        // ----------------------------------

        public PardotAPI.token token;
        public const string exampleUrl = "https://pi.pardot.com/api/<object>/version/3/do/<operator>/<identifier_field>/<identifier>";
        public string method = "xml";
        public string status;


        // ----------------------------------
        // ------- child interfaces ---------
        // ----------------------------------

        public PardotAPI.@interface campaigns;
        public PardotAPI.@interface custom_fields;
        public PardotAPI.@interface custom_redirects;
        public PardotAPI.@interface dynamic_contents;
        public PardotAPI.@interface emails;
        public PardotAPI.@interface email_templates;
        public PardotAPI.@interface forms;
        public PardotAPI.@interface lifecycle_histories;
        public PardotAPI.@interface lifecycle_stages;
        public PardotAPI.@interface lists;
        public PardotAPI.@interface list_memberships;
        public PardotAPI.@interface opportunities;
        public PardotAPI.@interface prospects;
        public PardotAPI.@interface prospect_accounts;
        public PardotAPI.@interface tags;
        public PardotAPI.@interface tag_objects;
        public PardotAPI.@interface users;
        public PardotAPI.@interface visitors;
        public PardotAPI.@interface visitor_activities;
        public PardotAPI.@interface visits;

        
        // ----------------------------------
        // --------- instantiation ----------
        // ----------------------------------

        public pardot()
        {
            string user = System.Configuration.ConfigurationManager.AppSettings.Get("PardotUser");
            string pass = System.Configuration.ConfigurationManager.AppSettings.Get("PardotPass");
            string ukey = System.Configuration.ConfigurationManager.AppSettings.Get("PardotUkey");

            instantiate(user, pass, ukey);
        }
        public pardot(string email, string password, string user_key)
        {
            instantiate(email, password, user_key);
        }

        public void instantiate(string email, string password, string user_key)
        { 
            // make sure parameters are filld out
            if ( email.notFilled() || password.notFilled() || user_key.notFilled() )
            {
                throw new System.ArgumentException("Email, password, and user key must be provided");
            }
            
            // create token from provided parameters
            token = new PardotAPI.token(email,password,user_key);

            // test token
            if ( !token.is_valid() )
            {
                status = "An error occurred creating the security token. Please double check your credentials.";
                PardotAPI.GlobalMethods.notifyAdmin(status);
            }

            // load child objects
            campaigns = new PardotAPI.@interface(ref token, "campaign");
            custom_fields = new PardotAPI.@interface(ref token, "custom_field");
            custom_redirects = new PardotAPI.@interface(ref token, "custom_redirect");
            dynamic_contents = new PardotAPI.@interface(ref token, "dynamic_content");
            emails = new PardotAPI.@interface(ref token, "email");
            email_templates = new PardotAPI.@interface(ref token, "email_template");
            forms = new PardotAPI.@interface(ref token, "form");
            lifecycle_histories = new PardotAPI.@interface(ref token, "lifecycle_history");
            lifecycle_stages = new PardotAPI.@interface(ref token, "lifecycle_stage");
            lists = new PardotAPI.@interface(ref token, "list");
            list_memberships = new PardotAPI.@interface(ref token, "list_membership");
            opportunities = new PardotAPI.@interface(ref token, "opportunity");
            prospects = new PardotAPI.@interface(ref token, "prospect");
            prospect_accounts = new PardotAPI.@interface(ref token, "prospect_account");
            tags = new PardotAPI.@interface(ref token, "tag");
            tag_objects = new PardotAPI.@interface(ref token, "tag_object"); ;
            users = new PardotAPI.@interface(ref token, "user");
            visitors = new PardotAPI.@interface(ref token, "visitor");
            visitor_activities = new PardotAPI.@interface(ref token, "visitor_activity");
            visits = new PardotAPI.@interface(ref token, "visit");
        }



        // ----------------------------------
        // ------------ methods -------------
        // ----------------------------------

        // made method private because it's not current supported
        private void changeMethod(string methodName)
        {
            // validate that the provided method name is either json or xml
            switch ( methodName.ToLower() )
            {
                case "json":
                    //method = methodName.ToLower();
                    break;
                case "xml":
                    //method = methodName.ToLower();
                    break;
            }
        }

        private bool notFilled(string str)
        {
            if ( str != null && str.Length > 0 )
            {
                return true;
            }
            return false;
        }

    }
}