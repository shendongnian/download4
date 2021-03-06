	[HttpPost]
    public ActionResult BookFlight(BookingModel booking)
    {
		if(ModelState.IsValid)
		{
			// booking.SelectedFlightId
		}
        // repopulate again the flights (this can be cached and/or be refactored a under method)
        using (var context = new FlightsDBEntities())
        {
            var flights = context.FlightsTables.ToList();
	        booking.Flights = flights.Select(f => new SelectListItem
								{
									Text = String.Format("{0} to {1}", f.Departure, f.Arrival),
									Value = f.FlightID.ToString()
								}).ToList();
	    }
     	return View(booking);
	}
