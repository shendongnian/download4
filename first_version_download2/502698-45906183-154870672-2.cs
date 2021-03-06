     public class SwaggerConfig
        {
            public static void Register(HttpConfiguration config)
            {
                var swaggerEnabledConfig = new SwaggerEnabledConfiguration(config, SwaggerDocsConfig.DefaultRootUrlResolver, new[] { "?format=json" });  // Empty string causes "undefined" to appear
                swaggerEnabledConfig.EnableSwaggerUi();
            }
        }
