	public ViewModeType ViewMode
	{
		get { return this.viewMode; }
		set
		{
			if (this.viewMode != value)
			{
				this.viewMode = value;
                                //You should notify property changed here
			}
		}
	}
