using System;
using System.Xml.Serialization;
using System.IO;

namespace ClickCounterApp.Business.Serializers.Xml.Transactions
{
    internal class TransformXmlToObject
    {
        internal object Execute(string schema, object objectName)
        {
            try
            {
                XmlSerializer oXmlSerializer = new XmlSerializer(objectName.GetType());
                return oXmlSerializer.Deserialize(new StringReader(schema));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
