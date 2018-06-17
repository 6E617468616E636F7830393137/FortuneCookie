using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClickCounterApp.Business.Serializers.Xml.Transactions
{
    internal class TransformObjectToXml
    {
        internal string Execute(object objectName)
        {
            XmlSerializer x = new XmlSerializer(objectName.GetType());
            string data;
            using (var sww = new StringWriter())
            {
                x.Serialize(sww, objectName);
                data = sww.ToString();
                return data;
            }
        }
    }
}
