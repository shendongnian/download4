    <Project>
      <PropertyGroup>
        <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
        <CodeAnalysisRuleSet>$(SolutionDir)Rules.ruleset</CodeAnalysisRuleSet>
      </PropertyGroup>
    
      <ItemGroup>
        <PackageReference Include="StyleCop.Analyzers" Version="1.1.118">
          <PrivateAssets>all</PrivateAssets>
          <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        </PackageReference>
      </ItemGroup>
    </Project>
