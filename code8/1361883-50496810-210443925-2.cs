        using Microsoft.AspNetCore.Http;
        //..
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddDbContext<ERPContext>((serviceProvider, options) =>
            {
                var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
                var httpRequest = httpContext.Request;
                var connection = GetConnection(httpRequest);
                options.UseSqlServer(connection);
            });
