    [Identifier(1000)]
    public class Rock : Entity<Rock> { }
    public abstract class Entity<T>
    {
        public static ushort Identifier
        {
            get
            {
                // How do I get here the current type of the object?
                Type currentType = typeof(T);
                foreach (IdentifierAttribute attribute in currentType.GetCustomAttributes(true))
                    return attribute.Identifier;
                throw new EntityException("No identifier has specified for this type of entity.");
            }
        }
    }
