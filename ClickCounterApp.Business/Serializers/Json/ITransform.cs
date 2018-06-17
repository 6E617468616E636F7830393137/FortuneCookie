namespace ClickCounterApp.Business.Serializers.Json
{
    public interface ITransform
    {
        object Transform(string xml, object objectName);
        string Transform(object objectName);
    }
}
