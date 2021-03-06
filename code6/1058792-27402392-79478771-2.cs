    public class FactoryBO
        {
            public static Dictionary<string, Func<FactoryBO>> objects =
                    new Dictionary<string, Func<FactoryBO>>
                        {
                                {"temporary registration", () => new TemporaryDriverRegistrationBO()},
                                {"driver registration", () => new DriverRegistrationBO()}
                        };
            public static FactoryBO CreateObject(string businessObjectName)
            {
                if (string.IsNullOrWhiteSpace(businessObjectName))
                {
                    return new FactoryBO();
                }
                Func<FactoryBO> objectCtor = null;
                objects.TryGetValue(businessObjectName.ToLower(), out objectCtor);
                return objectCtor != null ? objectCtor() : new FactoryBO();
            }
            public virtual SqlParameter[] GenerateQuery(params object[] StoredProcedureParameters)
            {
                return null;
            }
        }
