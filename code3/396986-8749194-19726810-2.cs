    <%@ WebHandler Language="C#" Class="Handler" %>
    using System.IO;
    public class NetworkImageHandler : System.Web.IHttpHandler
    {
      // Folder where all images are stored, process must have read access
      private const string NETWORK_SHARE = @"\\computer\share\";
      public void ProcessRequest(HttpContext context)
      {
          string fileName = context.Request.QueryString["fileName"];
          // Check for null or empty fileName
          // Check that this is only a file name, not something like "../../accounting/budget.xlsx"
          string path = Path.Combine(NETWORK_SHARE, fileName);
          // Check if file exists
          context.Response.ContentType = "image/jpg";
          context.Response.WriteFile(path, true);
      }
      public bool IsReusable { get { return false; } }
    }
