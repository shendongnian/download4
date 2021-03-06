    public IQueryable<ItemDTO> RepGetMonthItems(string inOut, string planFact, int month, int year = -1)
        {
            return GetItemsWithCategory().Where(i => i.InOut.Equals(inOut) 
              && i.PlanFact.Equals(planFact)) && year == -1? 
                i.DateTime.Month.Equals(month) : i.DateTime.Year.Equals(year));
        }
