
namespace ClickCounterApp.Business.Serializers.Xml
{
    public class Transform
    {
        //Declarations
        private readonly ITransform _transform;
        //Constructors
        public Transform(ITransform concreteImplementation)
        {
            _transform = concreteImplementation;
        }
        //Implementations
        public object Execute(string xml, object objectName)
        {
            return _transform.Transform(xml, objectName);
        }
        public object Execute(object objectName)
        {
            return _transform.Transform(objectName);
        }
    }
}
