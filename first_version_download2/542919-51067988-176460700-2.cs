    c.MultipleApiVersions(
        (apiDesc, targetApiVersion) => targetApiVersion.Equals("default", StringComparison.InvariantCultureIgnoreCase) ||                     // Include everything by default
                                        apiDesc.Route.RouteTemplate.StartsWith(targetApiVersion, StringComparison.InvariantCultureIgnoreCase), // Only include matching routes for other versions
        (vc) =>
        {
            vc.Version("default", "Swagger_Test");
            vc.Version("v1_0", "Swagger_Test V1_0");
            vc.Version("v2_0", "Swagger_Test V2_0");
        });
