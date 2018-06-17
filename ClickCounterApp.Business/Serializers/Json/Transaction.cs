namespace ClickCounterApp.Business.Serializers.Json
{
    public class Transaction
    {
        public class Execute : ITransform
        {
            public object Transform(string xml, object objectName)
            {
                return new Transactions.TransformJsonToObject().Execute(xml, objectName);
            }
            public string Transform(object objectName)
            {
                return new Transactions.TransformObjectToJson().Execute(objectName);
            }
        }
    }
}
