    public Foo : IFOO
    {
         public Foo(IRepository){}
    }
    
    public interface IFOO
    {
    }
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
          Bind<IRepository>.To<SQLBlogRepository>();
          Bind<IFOO>.To<Foo>();
         }
    }
