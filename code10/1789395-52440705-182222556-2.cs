    public void RemoveSewingCards(List<SewingCard> sewingCards, ApplicationDbContext context)
    {
        //iterating through sewingCards list
        foreach (var sewingCard in sewingCards)
        {               
            var sewingCardType = sewingCard.GetType();
            var dbSet = dbSets.Set(sewingCardType).Remove(sewingCard);
        }
    }
