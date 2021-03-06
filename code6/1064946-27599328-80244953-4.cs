    void Main()
    {
    	DataTable dt = new DataTable();  
    		dt.Columns.Add("ID");  
    		dt.Columns.Add("FirstName");  
    		dt.Columns.Add("Email");  
    	dt.Rows.Add(1,"Tim","tim@mail.com");
    	dt.Rows.Add(2,"Tim1","tim@mail.com");
    	dt.Rows.Add(3,"Tim2","tim2@mail.com");
    	dt.Rows.Add(4,"Tim3","tim3@mail.com");
    	
    	dt.AsEnumerable().Distinct(new DataRowComparer()).Dump();
    }
     public class DataRowComparer : IEqualityComparer<DataRow>  
    	{  
    		public bool Equals(DataRow t1, DataRow t2)  
    		{  
    			return (t1.Field<string>("Email")==t2.Field<string>("Email"));  
    		}  
    		public int GetHashCode(DataRow t)  
    		{  
    			return t.ToString().GetHashCode();  
    		}  
    	}  
