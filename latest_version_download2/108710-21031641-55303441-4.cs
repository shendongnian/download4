            IList<string> list1 = new List<string>();
            IList<string> list2 = new List<string>();
            list1.Add("Dog");
            list1.Add("Cat");
            list1.Add("Fish");
            list1.Add("Bird");
            list2.Add("Dog");
            list2.Add("Cat");
            list2.Add("Fish");
            list2.Add("Frog");
              int resultOfComparing = list1.Intersect(list2).Count();
            double accuracyPercentage = DetermineAccuracyPercentage(resultOfComparing,   list1.Count); 
