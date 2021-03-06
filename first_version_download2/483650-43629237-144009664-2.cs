            List<Configuration> lst = new List<Configuration>
			{
				new Configuration{Name="A", Config="X", Value="1"},
				new Configuration{Name="A", Config="X", Value="2"},
				new Configuration{Name="B", Config="Y", Value="2"}
			};
			var config = new Dictionary<string, NameValueCollection>();
			foreach (var c in lst)
			{
				if(config.Keys.Contains<String>(c.Name)){
					config[c.Name].Add(new NameValueCollection { {c.Config,c.Value } });
				}
				else{
				config.Add(c.Name, new NameValueCollection { {c.Config,c.Value } });
				}
			}
