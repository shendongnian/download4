        <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <configSections>
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
      </configSections>
      <entityFramework>
        <providers>
         <provider invariantName="System.Data.SQLite.EF6" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6" />
      <provider invariantName="System.Data.SQLite" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6" />
      </entityFramework>
      <connectionStrings>
        <add name="NorthwindContext" connectionString="Data Source=Northwind.sl3" providerName="System.Data.SQLite.EF6" />
      </connectionStrings>
      <system.data>
        <DbProviderFactories>
          <remove invariant="System.Data.SQLite.EF6" />
          <add name="SQLite Data Provider (Entity Framework 6)" invariant="System.Data.SQLite.EF6" description=".Net Framework Data Provider for SQLite (Entity Framework 6)" type="System.Data.SQLite.EF6.SQLiteProviderFactory, System.Data.SQLite.EF6" />
        </DbProviderFactories>
      </system.data>
    </configuration>
