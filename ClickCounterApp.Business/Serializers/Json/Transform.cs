
namespace ClickCounterApp.Business.Serializers.Json
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
        public object Execute(string json, object objectName)
        {
            return _transform.Transform(json, objectName);
        }
        public string Execute(object objectName)
        {
            return _transform.Transform(objectName);
        }
    }
}
