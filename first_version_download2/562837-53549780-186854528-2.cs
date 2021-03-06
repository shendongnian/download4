	#r "Newtonsoft.Json"
	#r "Microsoft.Azure.DocumentDB.Core"
	using System.Net;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Primitives;
	using Newtonsoft.Json;
	using Microsoft.Azure.Documents;
	using Microsoft.Azure.Documents.Client;
	private static DocumentClient client = new DocumentClient(new Uri("yourendpoint"), "yourkey");
	public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
	{
		log.LogInformation("C# HTTP trigger function processed a request.");
		string name = req.Query["name"];
		string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
		dynamic data = JsonConvert.DeserializeObject(requestBody);
		name = name ?? data?.name;
		return name != null
			? (ActionResult)new OkObjectResult($"Hello, {name}")
			: new BadRequestObjectResult("Please pass a name on the query string or in the request body");
	}
