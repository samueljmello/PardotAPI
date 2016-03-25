using System;
using System.IO;
using System.Net;
using System.Xml;

namespace PardotAPI
{

    // ---------------------------------------------------------
    // --------- request object ----------
    // ---------------------------------------------------------

    public class request
    {
        public string message;
        public string url;
        public PardotAPI.response response;
        public DateTime timestamp;
        
        public request(string thisUrl, string thisMessage, string interfaceName)
        {

            // make sure parameters are filld out
            if (thisMessage == null || thisUrl.notFilled() )
            {
                message = "Provided message and url can not be null & url must be valid.";
                return;
            }

            // set object properties
            message = thisMessage;
            url = thisUrl;

            // call this request
            call(interfaceName);
        }

        public void call(string interfaceName)
        {
            timestamp = DateTime.Now;

            WebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = message.Length;
            
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
            requestWriter.Write(message);
            requestWriter.Close();
            
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(request.GetResponse().GetResponseStream());

            response = new PardotAPI.response(interfaceName, xmlDoc);

            request.GetResponse().Close();
        }
    }
}