	private int _progress = 0;
	public int progress {
		get { return _progress; }
		set {
			_progress = value;
			if (progressBar.InvokeRequired) {
				this.Invoke(() => progressBar.Value == value);
			} else {
				progressBar.Value = value;
			}
		}
	}
