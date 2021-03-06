    var project = new Project(@"..\..\StackOverflow.csproj");
            var itemsToCopy = new List<ProjectItem>();
            var projectItems = project.Items;
            foreach (var projectItem in projectItems)
            {
                // e.g get all elements with CopyToOutputDirectory == "Always"
                var projectMetadata = projectItem.GetMetadata("CopyToOutputDirectory");
                if (projectMetadata != null && projectMetadata.EvaluatedValue == "Always")
                    itemsToCopy.Add(projectItem);
            }
            foreach (var projectItem in itemsToCopy)
            {
                // e.g get then Include-Attribute from <None Include="Configs\Config.config">
                var evaluatedInclude = projectItem.EvaluatedInclude;
            }
            // get the resources that are not set to CopyToOutputDirectory == "Always"
            var collection = project.GetItems("Resources");
            var resources = collection.Except(itemsToCopy);
            foreach (var projectItem in resources)
            {
                // e.g get then Include-Attribute from <Resource Include="Resources\Icons\icon8.png" />
                var evaluatedInclude = projectItem.EvaluatedInclude;
            }
