    <?xml version="1.0"?>
     <configuration>
     <configSections>
        <!-- For more information on Entity Framework configuration, visit     http://go.microsoft.com/fwlink/?LinkID=237468 -->
    <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false"/>
     </configSections>
    <entityFramework>
    <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
      <parameters>
        <parameter value="v11.0"/>
      </parameters>
    </defaultConnectionFactory>
    <providers>
      <provider invariantName="System.Data.SQLite" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6, Version=1.0.91.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139" />
    </providers>
    </entityFramework>
    <system.data>
    <DbProviderFactories>
      <remove invariant="System.Data.SQLite" />
      <add name="SQLite Data Provider" invariant="System.Data.SQLite" description=".Net Framework Data Provider for SQLite" type="System.Data.SQLite.SQLiteFactory, System.Data.SQLite, Version=1.0.91.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139" />
    </DbProviderFactories>
    </system.data>
    <connectionStrings>
     <add name="ChinookContext" connectionString="Data Source=|DataDirectory|Chinook_Sqlite_AutoIncrementPKs.sqlite" providerName="System.Data.SQLite"/>
    </connectionStrings>
    </configuration>
