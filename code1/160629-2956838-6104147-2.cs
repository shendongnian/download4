     StreamReader SR;
     string S;
     SR = File.OpenText(filename);
     S = SR.ReadLine();
     string name = "";
     string address = "";
     counter = 1;
     while (S != null)
     {
        if ((counter % 2) != 0)
           name = S;
        else
           address = S;
        S = SR.ReadLine();
        counter++;
        //do what you want with name and address here
 
     }
     SR.Close();
