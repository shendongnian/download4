    protected override void OnViewModelSet() {
        base.OnViewModelSet();
        var viewModel = ViewModel as INotifyPropertyChanged;
        if(viewModel != null) {
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == "SelectedMenu") {
                    if (Parent is MasterDetailPage master) {    
                        master.IsPresented = !master.IsPresented;
                    }
                }
            };
        }
    }
