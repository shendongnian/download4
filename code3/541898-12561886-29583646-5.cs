      public class AList : List<A>
      {
        public void CompareList(List<A> SecondaryList)
        {
          var compareResults = (from a in SecondaryList
                               join b in this on a.ID equals b.ID into gj
                               from subset in gj.DefaultIfEmpty()
                               select new { IsNew = (subset == null),
                                            IsUpdate = (subset != null && a.LastModifiedDate > subset.LastModifiedDate),
                                            Output = a}).ToList();
          foreach (var compareResult in compareResults)
          {
            if (compareResult.IsNew)
              this.Add(compareResult.Output);
            else if (compareResult.IsUpdate)
              this[this.IndexOf(this.FirstOrDefault(x => x.ID == compareResult.Output.ID))] = compareResult.Output;
          }
        }
      }
