    var matches =
        Players.GroupBy(player => player.Team_Name) //Group players by team name
            .Select(
                team => //For each team
                    new
                    {
                        TeamName = team.Key, //Select team name
                        AverageTimezone = //And average time zone
                            team
                            .Select(player => player.Account.Timezone)
                            .Average()
                    })
            .OrderBy(team => team.AverageTimezone) //Order teams by average time zone
            .Select((team, index) => new {Team = team, Index = index})
            .GroupBy(item => item.Index/2) //Group each two teams together (since the teams are ordered by average timezone, each two teams will have a close timezone)
            .Select(g => g.ToList())
            .Select(g => new Match
            {
                Team1 = g[0].Team.TeamName,
                Team2 = g[1].Team.TeamName
            })
            .ToList();
