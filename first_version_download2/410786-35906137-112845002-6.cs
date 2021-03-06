    [AllowAnonymous]
    public ActionResult Index()
    {
        if (Request.IsAuthenticated)
        {
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());
    
            // assuming there is some kind of relationship between products and users
            List<Product> products = db.Products.Where(p => p.User.Equals(currentUser.UserID)).ToList(); // or .email or other field from your users table
                
            // only send the products related to that user
            return View(products);
        }
        // User is not authenticated, send them all products
        return View(db.Products.ToList());
    }
