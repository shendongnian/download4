    var mainQuery = new BooleanQuery();
	var fnQuery = new BooleanQuery();
	fnQuery.Add(new WildcardQuery(new Term(FIRST_NAME, searchQuery)), Occur.SHOULD);
	fnQuery.Boost = 100f;
	var lnQuery = new BooleanQuery();
	lnQuery.Add(new WildcardQuery(new Term(LAST_NAME, searchQuery)), Occur.SHOULD);
	lnQuery.Boost = 75f;
	var bioQuery = new BooleanQuery();
	bioQuery.Add(new WildcardQuery(new Term(BIO, searchQuery)), Occur.SHOULD);
	bioQuery.Boost = 50f;
	mainQuery.Add(fnQuery, Occur.SHOULD);
	mainQuery.Add(lnQuery, Occur.SHOULD);
	mainQuery.Add(bioQuery, Occur.SHOULD);
	var hits = searcher.Search(mainQuery, null, SearchResultLimit, Sort.RELEVANCE);
