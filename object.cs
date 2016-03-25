using System.Reflection;
using System.Xml;

namespace PardotAPI
{
    public abstract class @object
    {
        // used to store the source
        protected XmlNode sourceData;
        protected bool isLoaded = false;
        
        // load object from data source
        public void finalizeLoad(XmlNode source)
        {
            sourceData = source;
            isLoaded = true;
        }

        // dynamic field setter
        public object this[string propertyName]
        {
            get
            {
                PropertyInfo property = this.GetType().GetProperty(propertyName);
                if (property != null)
                {
                    return property.GetValue(this, null);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                PropertyInfo property = this.GetType().GetProperty(propertyName);
                if (property != null)
                {
                    property.SetValue(this, value, null);
                }
            }
        }
        

        public void loadObject(XmlNode thisSource)
        {
            if (thisSource == null) return;
            if (thisSource.ChildNodes.Count > 0)
            {
                foreach (XmlNode prop in thisSource.ChildNodes)
                {
                    if (prop.InnerText != null)
                    {
                        this[prop.Name] = prop.InnerText.ToString();
                    }
                }
            }

            finalizeLoad(thisSource);
        }

    }
}