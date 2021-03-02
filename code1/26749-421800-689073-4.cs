    public class GenericComparer<T> : IComparer<T>
     {
        
         private string mDirection;
         private string mExpression;
        
         public GenericComparer(string Expression, string Direction)
         {
             mExpression = Expression;
             mDirection = Direction;
         }
        
         public int Compare(T x, T y)
         {
             PropertyInfo propertyInfo = typeof(T).GetProperty(mExpression);
             IComparable obj1 = (IComparable)propertyInfo.GetValue(x, null);
             IComparable obj2 = (IComparable)propertyInfo.GetValue(y, null);
             if (mDirection == "Ascending") {
                 return obj1.CompareTo(obj2);
             }
             else {
                 return obj2.CompareTo(obj1);
             }
         }
     }
