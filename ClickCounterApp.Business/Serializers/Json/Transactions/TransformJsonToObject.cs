using System;
using System.Web.Script.Serialization;

namespace ClickCounterApp.Business.Serializers.Json.Transactions
{
    internal class TransformJsonToObject
    {
        internal object Execute(string data, object objectName)
        {
            try
            {
                return new JavaScriptSerializer().Deserialize(data, objectName.GetType());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
