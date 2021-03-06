    public class NWEmpPhotoHandler : IHttpHandler 
    { 
        public bool IsReusable { get { return true; } } 
        
        public void ProcessRequest(HttpContext ctx) 
        { 
            string id = ctx.Request.QueryString["id"]; 
    
            SqlConnection con = new SqlConnection(<<INSERT CONNECTION STRING HERE>>); 
            SqlCommand cmd = new SqlCommand("SELECT Photo FROM Employees WHERE EmployeeID = @EmpID", con); 
            cmd.CommandType = CommandType.Text; 
            cmd.Parameters.Add("@EmpID", id); 
            
            con.Open(); 
            byte[] pict = (byte[])cmd.ExecuteScalar(); 
            con.Close(); 
    
            ctx.Response.ContentType = "image/bmp"; 
            ctx.Response.OutputStream.Write(pict, 78, pict.Length - 78); 
        } 
    } 
    
    
