    internal class UtilClass : IMyPublicInterface 
    { 
    }
    namespace MyProject 
    {
        public class PublicClass 
        {
            public IMyPublicInterface DoSomething() {} 
            public IMyPublicInterface { get; }
            // External assemblies now only need to know about the public interface.
        }
    }
