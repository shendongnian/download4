    	private string _Text = "";
        public string Text {
            get {
				return _Text;
            }
            set {
				if (_Text != value) {
					NotifyPropertyChanged ("Text");
				}
            }
        }
