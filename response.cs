using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace PardotAPI
{
    public class response
    {
        public string status;
        public string message;
        public string error = "0";
        public DateTime timestamp;
        public XmlDocument xml;
        public List<object> data;

        public response(string interfaceName, XmlDocument responseXml)
        {
            timestamp = DateTime.Now;
            xml = responseXml;

            XmlNode response = responseXml.SelectSingleNode("/rsp");
            if ( response != null )
            {
                status = response.Attributes["stat"].Value;
                message = "Response Successful";

                if (status == "fail")
                {
                    XmlNode errorNode = xml.SelectSingleNode("/rsp/err");
                    message = errorNode.InnerText;
                    error = errorNode.Attributes["code"].Value;
                }
            }
            else
            {
                throw new System.ArgumentException("A valid response was not received from Pardot.");
            }
        }

        public bool isValid()
        {
            if ( status == "ok" )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // response string included in response from API. This method not needed.
        public string getMessageFromCode(int code)
        {
            string message = "";
            switch ( code )
            {
                case 1: message = "Invalid API key or user key"; break;
                case 2: message = "Invalid action"; break;
                case 3: message = "Invalid prospect ID"; break;
                case 4: message = "Invalid prospect email address"; break;
                case 5: message = "Invalid query parameters"; break;
                case 6: message = "Invalid time frame"; break;
                case 7: message = "Invalid timestamp"; break;
                case 8: message = "Invalid time range"; break;
                case 9: message = "A prospect with the specified email address already exists"; break;
                case 10: message = "Invalid user ID"; break;
                case 11: message = "Invalid user email address"; break;
                case 12: message = "Invalid group ID"; break;
                case 13: message = "One or more required parameters are missing"; break;
                case 14: message = "Non-existent prospect ID; No email address provided"; break;
                case 15: message = "Login failed"; break;
                case 16: message = "Invalid ID"; break;
                case 17: message = "Invalid ID range"; break;
                case 18: message = "Invalid value for profile criteria matching status"; break;
                case 19: message = "Invalid value specified for sort_by"; break;
                case 20: message = "Invalid value specified for sort_order"; break;
                case 21: message = "Invalid value specified for offset"; break;
                case 22: message = "Unsupported feature in this version of the API"; break;
                case 23: message = "Invalid value specified for limit"; break;
                case 24: message = "Invalid visitor ID"; break;
                case 25: message = "Parameter is_starred must be true or false"; break;
                case 26: message = "Parameter assigned must be true or false"; break;
                case 27: message = "Parameter deleted must be true or false"; break;
                case 28: message = "Parameter new must be true or false"; break;
                case 29: message = "Invalid value specified for score"; break;
                case 30: message = "Invalid score range specified"; break;
                case 31: message = "Invalid combination of parameters for score"; break;
                case 32: message = "Invalid value specified for grade"; break;
                case 33: message = "Invalid grade range specified"; break;
                case 34: message = "Invalid grade range specified"; break;
                case 35: message = "Invalid opportunity ID"; break;
                case 36: message = "One or more required parameter values are missing"; break;
                case 37: message = "A SalesForce connector was detected"; break;
                case 38: message = "Invalid campaign ID"; break;
                case 39: message = "Invalid profile ID"; break;
                case 40: message = "Invalid opportunity probability"; break;
                case 41: message = "Invalid probability range specified"; break;
                case 42: message = "Invalid opportunity value"; break;
                case 43: message = "Invalid opportunity value range specified"; break;
                case 44: message = "The provided prospect_id and prospect_email parameters do not match"; break;
                case 45: message = "The provided user_id and user_email parameters do not match"; break;
                case 46: message = "This API user lacks sufficient permissions for the requested operation"; break;
                case 47: message = "Multiple assignment targets were specified"; break;
                case 48: message = "Invalid visit ID"; break;
                case 50: message = "Invalid boolean"; break;
                case 51: message = "Invalid parameter"; break;
                case 53: message = "Client IP address/location must be activated before accessing API"; break;
                case 54: message = "Email address is already in use"; break;
                case 55: message = "Invalid list ID"; break;
                case 56: message = "Invalid number entered for field"; break;
                case 57: message = "Invalid date entered for field"; break;
                case 58: message = "That prospect is already a memeber of that list. Update the membership instead."; break;
                case 59: message = "A CRM connector was detected"; break;
                case 60: message = "Invalid HTTP request method"; break;
                case 61: message = "Invalid prospect account id"; break;
                case 62: message = "Conflicting Update"; break;
                case 63: message = "Too many IDs specified"; break;
                case 64: message = "Email content missing required variables"; break;
                case 65: message = "Invalide email format"; break;
                case 66: message = "You have exceeded your concurrent request limit.  Please wait, before trying again"; break;
                case 10000: message = "..."; break;
            }
            return message;
        }
    }
}