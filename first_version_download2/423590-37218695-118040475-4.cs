    public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
			app.UseCors(CorsOptions.AllowAll);
		}
	}
