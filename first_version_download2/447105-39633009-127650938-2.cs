    public override void ViewDidLoad()
    		{
    			//Normal way
    			//this.Title = "Normal";//or this.NavigationItem.Title = "Normal;
    			//Using custom view
    			UILabel lbTitle = new UILabel(new CoreGraphics.CGRect(0, 0, 50, 30));
    			lbTitle.Text = "CustomView";
    			lbTitle.TextColor = UIColor.Red;
    			this.NavigationItem.TitleView = lbTitle;
    			////Using a picture
    			//this.NavigationItem.TitleView = lbTitle;
    		}
