    List<ShoeModels> res = loopData;   // here I declare and assign res variable, it should be outside of the loop
	
	for (int i = 5; i < query.count; i++)
	{
		if (ps[i].value.All(char.IsDigit))
        {
            query.numValue = float.Parse(ps[i].value);
        }
        else
        {
            query.filterValue = ps[i].value;
        }
        query.filterColumn = ps[i].col;
        query.opr = ps[i].opr;
        query.opr = query.opr.ToLower();
        IEnumerable<ShoeModels> tuyo = null;
		if (query.opr == "gt" || query.opr == "lt" || query.opr == "gte" || query.opr == "lte" || query.opr == "ne")
        {
            // apply filtering to the res variable
            tuyo = res.Where(a => comparer(a, query.filterColumn, query.opr, query.numValue));
        }
        else if (query.opr.ToLower() == "like")
        {
            // apply filtering to the res variable
            tuyo = res.Where(a => a[query.filterColumn].Contains(query.filterValue));
        }
        // update res variable, so on the next iteration we will operate on updated (filtered) list
		res = tuyo.ToList();
	}
