    public class SomeModelModelBinder : DefaultModelBinder
    {
         public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
         {
             if (bindingContext.ModelType == typeof(ISomeModel))
             {
                 HttpRequestBase request = controllerContext.HttpContext.Request;
                 bindingContext.ValueProvider.GetValue(bindingContext.ModelName + ".Value");
                 [some logic to return a new SomeModelAttribute<something>();]
             }
             else
             {
                 return base.BindModel(controllerContext, bindingContext);
             }
         }
    }
