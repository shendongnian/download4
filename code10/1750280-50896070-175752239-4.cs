    var phoneCall = new StateMachine<State, Trigger>(State.OffHook);
    phoneCall.Configure(State.OffHook)
        .Permit(Trigger.CallDialled, State.Ringing);
    	
    phoneCall.Configure(State.Ringing)
        .Permit(Trigger.CallConnected, State.Connected);
     
    phoneCall.Configure(State.Connected)
        .OnEntry(() => StartCallTimer())
        .OnExit(() => StopCallTimer())
        .Permit(Trigger.LeftMessage, State.OffHook)
        .Permit(Trigger.PlacedOnHold, State.OnHold);
    
    // ...
    
    phoneCall.Fire(Trigger.CallDialled);
    Assert.AreEqual(State.Ringing, phoneCall.State);
