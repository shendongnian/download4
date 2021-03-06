    public interface IEntityTypeTransform
    {
        Func<IDataRecord, object> GetDataTransform();
    }
    public abstract class EntityTypeTransform<T> : IEntityTypeTransform
    {
        public abstract Func<IDataRecord, object> GetDataTransform();
    }
    public class TaskParameterEntityTypeTransform : EntityTypeTransform<TaskParameter>
    {
        public override Func<IDataRecord, object> GetDataTransform()
        {
            return dataRecord => new TaskParameter()
            {
                TaskId = (int)dataRecord["task id"],
            };
        }
    }
    public class TransformDistributor
    {
        private readonly Dictionary<Type, IEntityTypeTransform> _transforms = new Dictionary<Type, IEntityTypeTransform>();
        public void Add<T>(EntityTypeTransform<T> type)
        {
            this._transforms.Add(typeof(T), type);
        }
        public T Transform<T>(IDataRecord record)
        {
            var transform = this._transforms[typeof(T)].GetDataTransform()(record);
            if (transform is T)
            {
                return (T)transform;
            }
            else
            {
                // theorically can't happen
                throw new InvalidOperationException("transformer doesn't return instance of type " + transform.GetType().Name);
            }
        }
    }
