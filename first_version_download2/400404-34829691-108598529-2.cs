    container.Register(Component.For(typeof(IDataProvider<ISqlDbEntity>))
                    .ImplementedBy(typeof(SqlDataProvider<>))
                    .LifestylePerWebRequest());
    
                container.Register(Component.For(typeof(IDataProvider<IMongoDbEntity>))
                    .ImplementedBy(typeof(MongoDataProvider<>))
                    .DependsOn(Dependency.OnAppSettingsValue("databaseName", "MongoDatabaseName"))
                    .LifestylePerWebRequest());
