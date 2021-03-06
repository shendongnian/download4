    public static class DataRowExtensions
    {
        /// <summary>
        /// Maps DataRow objecto to entity T depending on the defined attributes. 
        /// </summary>
        /// <typeparam name="T">Entity to map.</typeparam>
        /// <param name="rowInstance">DataRow instance.</param>
        /// <returns>Instance to created entity.</returns>
        public static T MapRow<T>(this DataRow rowInstance) where T : class, new()
        {
            //Create T item
            T instance = new T();
            Mapper<T>.MapRow(instance, rowInstance);
            return instance;
        }    
        private static class Mapper<T> where T : class
        {
            private static readonly Mapper[] __mappers;
            static Mapper()
            {
                __mappers = typeof(T)
                    .GetProperties()
                    .Where(p=>p.IsDefined(typeof(MappingAttribute), false)
                    .Select(p=>new
                        {
                            Property = p,
                            Attribute = p
                                .GetCustomAttributes(typeof(MappingAttribute), false)
                                .Cast<MappingAttribute>()
                                .FirstOrDefault()
                        }    
                    .Select(m=>new Mapping(m.Property, m.Attribute))
                    .ToArray()
            }    
    
            public void MapRow(T instance, DataRow row)
            {
                foreach(var mapper in __mappers)
                {
                    mapper.MapRow(instance, row);
                }
            }
        }
        private sealed class Mapper
        {
            private readonly PropertyInfo _property;
            private readonly MappingAttribute _attribute;
            public Mapper(PropertyInfo property, MappingAttribute _attribute)
            {
                _property = property;
                _attribute = attribute;
            }
            public void MapRow(T instance, DataRow rowInstance)
            {
                //TODO: Implement this with the code already provided
            }
        }
    }
