        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserId, string RoleName)
        {
            User user = context.Users.Where(u => u.Id.Equals(UserId, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userManager = new UserManager<User>(new UserStore<User>(new ApplicationDbContext()));
            ViewBag.RolesForThisUser = userManager.GetRoles(user.Id);
            var idResult = userManager.AddToRole(user.Id, RoleName);
            if (user.AccountNew)
            {
                user.AccountNew = false;
                context.SaveChanges(); //This fixed it!
            }
