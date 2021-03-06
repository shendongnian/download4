	public class UsersWithRoleController : Controller
	{
        private readonly ApplicationUserManager userManager;
	    public UsersWithRoleController(ApplicationUserManager userManager)
	    {
	        this.userManager = userManager;
	    }
	    public ActionResult GetUsersWithRoles(string roleName)
	    {
	        var users = userManager.GetUsersInRole(roleName);
            var viewModel = new GetUsersWithRolesViewModel()
            {
                RoleName = roleName,
                Users = users,
            };
	        return View(viewModel);
	    }
    }
    public class GetUsersWithRolesViewModel
    {
        public String RoleName { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
