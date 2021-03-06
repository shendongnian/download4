    class MyFancyItemsViewModel
    {
         public MyFancyItemsViewModel()
         {  
             var incrementalObservablCollcetion = new IncrementalLoading...(GetItemsFromInternetOrSmth);
             incrementalObservablCollcetion.LoadMoreItemsStarted += OnItemsLoadingStarted;
             incrementalObservablCollcetion.LoadMoreItemsCompleted += OnItemsLoadingCompleted;
              
              ItemsBindedInXaml = incrementalObservablCollcetion;
         }
        
         private Task<IEnumerable<Items>> GetItemsFromInternetOrSmth(CancellationToken cancelToken)
         {
          ... do some work returns enumerable of Items
         }
         private void OnItemsLoadingStarted()
         { .. do smth .. }
         private void OnItemsLoadingCompleted()
         { ... do smth .. } 
         
         public ObservableCollection<Items> ItemsBindedInXaml { get; private set; }
    }
