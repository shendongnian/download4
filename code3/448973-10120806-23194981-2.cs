    private void btnZoek_Click(object sender, EventArgs e)         
    {             
        int counter = 0; string line;               
        StringBuilder sb = new StringBuilder();
        // Read the file and display it line by line.              
        using(System.IO.StreamReader file = new System.IO.StreamReader("c:\\log.txt"))
        {
           while((line = file.ReadLine()) != null)             
           {     
             if ( line.Contains(txtZoek.Text) )                  
             {          
                  // This append the text and a newline into the StringBuilder buffer       
                  sb.AppendLine(line.ToString());
             }                   
          }               
       }
       txtResult.Text = sb.ToString();
    }  
