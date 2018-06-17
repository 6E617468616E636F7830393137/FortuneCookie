using System;
using System.Web.Script.Serialization;

namespace ClickCounterApp.Business.Serializers.Json.Transactions
{
    internal class TransformObjectToJson
    {
        internal string Execute(object objectName)
        {
            try
            {
                return new JavaScriptSerializer().Serialize(objectName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
