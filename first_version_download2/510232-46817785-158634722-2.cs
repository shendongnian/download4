    string filename = "myfile.zip";
    string serverpath = Server.MapPath($"~/{filename}");
    FileInfo file = new FileInfo(serverpath);
    Response.Clear();
    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
    Response.AddHeader("Content-Length", file.Length.ToString());
    Response.ContentType = "application/zip";
    Response.WriteFile(file.FullName);
    Response.Flush();
    Response.End();
