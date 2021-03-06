    public class InvokableMethod
    {
        readonly MethodSignature signature;
        readonly Delegate invokableMethod;
        public InvokableMethod(Delegate invokableMethod, params Type[] types)
            :this(invokableMethod, new MethodSignature(types))
        {
        }
        public InvokableMethod(Delegate invokableMethod, MethodSignature signature)
        {
            Debug.Assert(invokableMethod != null);
            this.invokableMethod = invokableMethod;
            this.signature =signature;
        }
        public Delegate InvokableOverload { get { return this.invokableMethod; } }
        public MethodSignature Signature { get { return this.signature; } }
    }
    public class MethodSignature: IEquatable<MethodSignature>
    {
        readonly List<Type> signature;
        public MethodSignature(params Type[] types)
        {
            this.signature = types.ToList();
        }
        public IEnumerable<Type> Signature { get { return this.signature; } }
        public override bool Equals(object obj)
        {
            var methodSignature = obj as MethodSignature;
            if (methodSignature == null)
                return false;
            return this.Equals(methodSignature);
        }
        public bool Equals(MethodSignature other)
        {
            if (other == null)
                return false;
            if (other.signature.Count != this.signature.Count)
                return false;
            for (int i = 0; i < this.signature.Count; ++i)
            {
                if (this.signature[i] != other.signature[i])
                    return false;
            }
            return true;
        }
    }
