    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddAuthentication();
            services.AddCaching();
        }
        public void Configure(IApplicationBuilder app) {
            // Add a new middleware validating access tokens issued by the OIDC server.
            app.UseJwtBearerAuthentication(options => {
                options.AutomaticAuthentication = true;
                options.Authority = "http://localhost:50000/";
                options.RequireHttpsMetadata = false;
                // IMPORTANT: when making your token request, add the "resource" parameter
                // containing the URL-encoded address of your API
                // (e.g grant_type=password&username=Username&password=Password&resource=http%3A%2F%2Flocalhost%3A54540%2F).
                // Alternatively, you can also disable audience validation,
                // but it has one downside: id_token will also be accepted by default.
                // Using the "resource" parameter is RECOMMENDED.
                // options.TokenValidationParameters.ValidateAudience = false;
            });
            // Add a new middleware issuing tokens.
            app.UseOpenIdConnectServer(options => {
                options.Provider = new OpenIdConnectServerProvider {
                    // Override OnValidateClientAuthentication to skip client authentication.
                    OnValidateClientAuthentication = context => {
                        // Call Skipped() since JS applications cannot keep their credentials secret.
                        context.Skipped();
                        return Task.FromResult<object>(null);
                    },
                    // Override OnGrantResourceOwnerCredentials to support grant_type=password.
                    OnGrantResourceOwnerCredentials = context => {
                        // Do your credentials validation here.
                        // Note: you can call Rejected() with a message
                        // to indicate that authentication failed.
                        var identity = new ClaimsIdentity(OpenIdConnectDefaults.AuthenticationScheme);
                        identity.AddClaim(ClaimTypes.NameIdentifier, "todo");
                        // By default, claims are not serialized in the access and identity tokens.
                        // Use the overload taking a "destination" to make sure your claims
                        // are correctly inserted in the appropriate tokens.
                        identity.AddClaim("urn:customclaim", "value", "token id_token");
                        context.Validated(new ClaimsPrincipal(identity));
                        return Task.FromResult<object>(null);
                    }
                }
            });
            app.UseMvc();
        }
    }
