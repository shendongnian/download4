    if (player.Stars < 20 && text[0] != '/' && DateTime.UtcNow - player.LastTalked < TimeSpan.FromMinutes(1))
    {
        player.SendInfo("You may only talk once per minute.");
        return;
    }
    player.LastTalked = DateTime.UtcNow;
