    public static Expression<Func<T,bool>> IsVisible<T>(DateTime now) 
        where T:IHaveItem
    {
       return // enter your lambda here - getting an error from SO !
       return x => x.Item.DateVisible != null x.Item.DateVisible < now;
    }
