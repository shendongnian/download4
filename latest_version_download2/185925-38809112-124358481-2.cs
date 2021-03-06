    public class FavoriteController
    {
       protected GitContext db;
       public FavoriteController()
       {
         db=new GitContext();
       }
      public IEnumerable<GitUser> FavoritesUsers(int cookieId, int count)
      {
            return FavoritesUsersListFromHistory(TopFavoritesUsers(cookieId, count));
      }
      //create a class (CookiesHistoryDTO) to save the result of this query
      public IQueryable<CookiesHistoryDTO> TopFavoritesUsers(int cookieId, int count)
      {
        
            IQueryable<CookiesHistoryDTO> results = (from ch in db.CookiesHistory
                                                   where ch.GitUserId != null
                                                   where ch.MyCookieId == cookieId
                                                   group ch by new { ch.GitUserId, ch.MyCookieId, ch.SearchGitUser } into g
                                                   orderby g.Count() descending
                                                   select new CookiesHistoryDTO{ GitUserId = g.Key.GitUserId, MyCookieId = g.Key.MyCookieId, SearchGitUser = g.Key.SearchGitUser, Count = g.Count() }
                                                  ).Take(count);
            return results;
        
      }
      public IEnumerable<GitUser> FavoritesUsersListFromHistory(IQueryable<CookiesHistoryDTO> user)
      {
         //Here the context you use to create your first query is still alive
         var userIds=user.Select(e=>e.GitUserId).Contains(e.Id);
         return db.GitUsers.Where(e=>userIds.Contains(e.Id)).ToList();// Here is when both query are going to be executed.
      }
      protected override void Dispose(bool disposing)
      {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
      }
    }
