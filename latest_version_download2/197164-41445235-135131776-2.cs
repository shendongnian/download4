    public async Task<(int fCount, int cCount, int aCount)> GetAllStatsAsync()
    {
        // Some code...
        //fCount, cCount, aCount are not defined here, so you should define them
        
        var fCount = 0;
        var cCount= 0;
        var aCount = 0;
        return (fCount , cCount, aCount );
        //Other ways:
        //return (fCount : 0, cCount: 0, aCount : 0);
        //return new (int fCount , int cCount, int aCount ) { fCount = 0, cCount = 0, aCount = 0 };
    }
	public async Task<HttpResponseMessage> GetInfoAsync()
	{
		// Some code...
		var stats = await _myClass.GetAllStatsAsync();
		var vm = new ViewModel
				 {
					 FCount = stats.fCount,
					 CCount = stats.cCount,
					 ACount = stats.aCount
				 };
		 return Request.CreateResponse(HttpStatusCode.OK, vm);
	}
