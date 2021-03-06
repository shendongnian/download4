      public void ConfigureServices(IServiceCollection services) {
        // .... Ignore code before this
    
       // Auto Mapper Configurations
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new ViewModelToEntityProfile());
        });
    
        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
    
        services.AddMvc();
    }
