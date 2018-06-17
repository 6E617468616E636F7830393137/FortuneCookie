namespace ClickCounterApp.Business.Serializers.Xml
{
    public class Transaction
    {
        public class Execute : ITransform
        {
            public object Transform(string xml, object objectName)
            {
                return new Transactions.TransformXmlToObject().Execute(xml, objectName);
            }
            public string Transform(object objectName)
            {
                return new Transactions.TransformObjectToXml().Execute(objectName);
            }
        }
    }
}
