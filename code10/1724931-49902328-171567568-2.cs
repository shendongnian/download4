        double index = 5;
        double higher = 0 ;
        double lower = 0;
    
        List<double> list = new List<double>() { 1, 2, 3, 7, 8, 9, };
        list.Sort();//Sort list from low to high numbers
        if(!list.Contains(index))
        {
          foreach (var item in list)
          {
             if(item < index)
             {
                lower = item;                      
             }
             if (item > index)
             {
                 higher = item;  
                 break;  
             }
           }
         }
    Console.WriteLine(index);//5
    Console.WriteLine(lower);//3
    Console.WriteLine(higher);//7
