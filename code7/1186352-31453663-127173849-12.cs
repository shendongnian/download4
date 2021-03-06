	public class HomeController : Controller
	{
		private readonly IOptions<MyConfig> config;
	
		public HomeController(IOptions<MyConfig> optionsAccessor)
		{
			this.config = config;
		}
	
		// GET: /<controller>/
		public IActionResult Index() => View(config.Value);
	}
