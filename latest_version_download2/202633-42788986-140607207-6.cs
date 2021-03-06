    public Geoposition getCurrentPosition() 
    {
      Geoposition position = null;
      try
      {
         var locator = CrossGeolocator.Current;
         locator.DesiredAccuracy = 50;
    
         position = locator.GetPositionAsync(timeoutMilliseconds: 10000).Result;
    
         Debug.WriteLine("Position Status: {0}", position.Timestamp);
         Debug.WriteLine("Position Latitude: {0}", position.Latitude);
         Debug.WriteLine("Position Longitude: {0}", position.Longitude);
    
      }
      catch (Exception ex)
      {
         Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
      }
      return position;
       
    }
