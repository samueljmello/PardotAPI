using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml;

namespace PardotAPI
{
    public class @interface
    {
        private PardotAPI.token token;
        private string interfaceName;
        private string baseUrl = "{0}/version/3/do/{1}";
        private const string identifierUrl = "/{2}/{3}";
        private const string baseMessage = "api_key={0}&user_key={1}";

        public @interface(ref PardotAPI.token thisToken, string thisInterface)
        {
            interfaceName = thisInterface;
            token = thisToken;

            // prepend API url to the baseUrl call
            baseUrl = GlobalConstants.pardotAPIUrl + "/" + baseUrl;
        }
        public PardotAPI.request create(Dictionary<string, string> parameters)
        {
            return create("email", parameters["email"], parameters);
        }
        public PardotAPI.request create(string thisIdentifierField, string thisIdentifier, Dictionary<string,string> parameters)
        {
            string url = string.Format(baseUrl + identifierUrl, interfaceName, "create", thisIdentifierField, thisIdentifier);
            PardotAPI.request request = new PardotAPI.request(url, getMessage(parameters), interfaceName);
            request.response.data = loadObjects(request);
            return request;
        }
        public PardotAPI.request read(string thisIdentifierField, string thisIdentifier)
        {
            return read(thisIdentifierField, thisIdentifier, new Dictionary<string,string>());
        }
        public PardotAPI.request read(string thisIdentifierField, string thisIdentifier, Dictionary<string, string> parameters)
        {
            string url = string.Format(baseUrl + identifierUrl, interfaceName, "read", thisIdentifierField, thisIdentifier);
            PardotAPI.request request = new PardotAPI.request(url, getMessage(parameters), interfaceName);
            request.response.data = loadObjects(request);
            return request;
        }
        public PardotAPI.request query()
        {
            return query("", "", new Dictionary < string, string >() );
        }
        public PardotAPI.request query(string thisIdentifierField, string thisIdentifier, Dictionary<string, string> parameters)
        {
            string url = "";
            if (thisIdentifierField.notFilled() && thisIdentifier.notFilled())
            {
                url = string.Format(baseUrl, interfaceName, "query");
            }
            else
            {
                url = string.Format(baseUrl + identifierUrl, interfaceName, "query", thisIdentifierField, thisIdentifier);
            }
            PardotAPI.request request = new PardotAPI.request(url, getMessage(parameters), interfaceName);
            request.response.data = loadObjects(request);
            return request;
        }
        public PardotAPI.request update(string thisIdentifierField, string thisIdentifier, Dictionary<string, string> parameters)
        {
            string url = string.Format(baseUrl + identifierUrl, interfaceName, "update", thisIdentifierField, thisIdentifier);
            return new PardotAPI.request(url, getMessage(parameters), interfaceName);
        }
        public PardotAPI.request upsert(string thisIdentifierField, string thisIdentifier, Dictionary<string, string> parameters)
        {
            string url = string.Format(baseUrl + identifierUrl, interfaceName, "upsert", thisIdentifierField, thisIdentifier);
            return new PardotAPI.request(url, getMessage(parameters), interfaceName);
        }
        private string loadParameters(Dictionary<string, string> parameters)
        {
            string data = "";
            if (parameters.Count > 0)
            {
                foreach ( KeyValuePair<string, string> entry in parameters)
                {
                    data += "&" + entry.Key.ToString() + "=" + HttpUtility.UrlEncode(entry.Value.ToString());
                }
            }
            return data;
        }
        private string getMessage(Dictionary<string, string> parameters)
        {
            return string.Format(baseMessage, token.hash, token.user_key) + loadParameters(parameters);
        }
        private List<object> loadObjects(PardotAPI.request request)
        {
            List<object> objects = new List<object>();
            if (request.response.isValid())
            {
                XmlNode data = request.response.xml.SelectSingleNode("/rsp/result");
                if (data == null )
                {
                    data = request.response.xml.SelectSingleNode("/rsp");
                }

                if (data != null && data.ChildNodes.Count > 0 )
                {
                    foreach (XmlNode x in data.ChildNodes)
                    {
                        if (x.Name != "total_results")
                        {
                            objects.Add(loadObject(x));
                        }
                    }
                }
            }
            return objects;
        }
        private object loadObject(XmlNode data)
        {
            return Activator.CreateInstance(Type.GetType("PardotAPI." + interfaceName), data);
        }
    }
}