namespace ClickCounterApp.Business.Serializers.Xml
{
    public interface ITransform
    {
        object Transform(string json, object objectName);
        string Transform(object objectName);
    }
}
