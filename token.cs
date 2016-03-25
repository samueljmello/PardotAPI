using System;
using System.IO;
using System.Net;
using System.Xml;

namespace PardotAPI
{
    public class token
    {

        // ----------------------------------
        // --------- properties -------------
        // ----------------------------------

        private string _email;
        private string _password;
        private string _url = "/login/version/3";
        private double _expiration = 1;
        
        private string _hash;
        private DateTime _timestamp;
        private string _user_key;

        private string _status = "Token not instantiated.";

    

        // ----------------------------------
        // --------- instantiation ----------
        // ----------------------------------
        public token(string thisEmail, string thisPassword, string thisUserKey)
        {
            // set private properties from instantiation
            _email      = thisEmail;
            _password   = thisPassword;
            _user_key   = thisUserKey;

            // prepend API url to login url
            _url = GlobalConstants.pardotAPIUrl + _url;

            // call create method to get security token
            create();
        }



        // ---------------------------------------------------------
        // ------- getters & setters for private properties --------
        // ---------------------------------------------------------

        public string hash
        {
            get
            {
                // if either _hash or _timestamp property are null, or token timestamp has expired (expires after 60 minutes)
                if ( !is_valid() )
                {
                    // call create again
                    create();
                }

                return _hash;
            }
        }

        public DateTime timestamp
        {
            get
            {
                return _timestamp;
            }
        }

        public string user_key
        {
            get
            {
                return _user_key;
            }
        }


        // ---------------------------------------------------
        // ------------ private & public methods -------------
        // ---------------------------------------------------

        private void create()
        {

            // create post data string
            string message = string.Format("email={0}&password={1}&user_key={2}", _email, _password, _user_key);
            PardotAPI.request request = new PardotAPI.request(_url, message, "authentication");

            // validate this was successful
            if ( request.response.isValid() )
            {
                // get the api_key from the response
                XmlNode key = request.response.xml.SelectSingleNode("/rsp/api_key");

                // set the hash and timestamp
                _hash = key.InnerText;
                _timestamp = DateTime.Now;

                _status = "Token created successfully.";
            }
            else
            {
                _status = "Authentication failed. Response from server: " + request.response.message;
            }
        }

        public bool is_valid()
        {
            if ( _hash != null && _timestamp != null && DateTime.Compare(DateTime.Now, _timestamp.AddHours(_expiration)) < 0)
            {
                return true;
            }
            return false;
        }
    }
}