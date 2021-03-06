    public class ProductController : Controller
    {
        public ActionResult Create(
            [Bind(Exclude = "Id")] Product productToCreate)
        {
            try
            {
                this.service.CreateProduct(productToCreate);
            }
            catch (ValidationException ex)
            {
                MvcValidationExtension.AddModelErrors(this.ModelState, ex);
                return View();
            }
            
            return RedirectToAction("Index");
        }
    }
    public static class MvcValidationExtension
    {
        public static void AddModelErrors(this ModelStateDictionary state, 
            ValidationException exception)
        {
            foreach (var error in ex.ValidationErrors)
                state.AddModelError(error.Key, error.Message);
        }
    }
