    private void button1_Click(object sender, EventArgs e)
    {
        var api = RiotApi.GetInstance("RGAPI-5d9498bf-d163-4074-991b-071ff612e496");
        // if we have api, try get the game
        var game = api != null 
          ? api.GetCurrentGame(RiotSharp.Platform.EUW1, 79200188)
          : null;
        // if we have game, process the players 
        if (game != null)
            foreach (var player in game.Participants) 
            {
                //TODO: put relevant logic here
            }
    }
