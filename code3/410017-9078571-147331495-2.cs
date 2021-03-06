    public partial class Form1 : Form
    {
       private SqlCeConnection _conn;
       public Form1()
       {
         InitializeComponent();
         this.dataGridView1.AutoGenerateColumns = true;
       }
       private void Form1_Load(object sender, EventArgs e)
       {
         SqlCeDataReader rdr = null;
         try
         {
           using(SqlCeConnection conn = new SqlCeConnection(@"Data Source = |DataDirectory|\Database1.sdf"))
           {
               conn.Open();
               SqlCeCommand sqlcmd = new SqlCeCommand("SELECT ID, UserName FROM Table1", conn);
               sqlcmd.Connection.Open();
               rdr = sqlcmd.ExecuteReader();
               //Custom Object is object with same structure as your data table
               List<CustomObject> dataSource = new List<CustomObject>();
               while (rdr.Read())
               {
                   var customObject = new CustomObject();
                   customObject.Id = rdr.GetInt32(0);
                   //so on
                   dataSource.Add(customObject);
               }
               this.bindingSource1.DataSource = dataSource;
               rdr.Close();
           }
        }
        catch(Exception ex)
        { 
           //Handle Exception
        }
      }
    }
