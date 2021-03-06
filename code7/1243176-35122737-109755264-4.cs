    	const int MaxLineCount = 10;
        const int MaxLineLength = 200;
		public static readonly DependencyProperty NotesTextProperty =
				DependencyProperty.Register(
					name: "NotesText",
					propertyType: typeof( String ),
					ownerType: typeof( SampleTextBoxEntryWindow ),
					typeMetadata: new PropertyMetadata(
						defaultValue: string.Empty,
						propertyChangedCallback: OnNotesTextPropertyChanged,
						coerceValueCallback: CoerceTextLineLimiter ) );
        public string NotesText
	    {
		    get { return (String)GetValue( NotesTextProperty ); }
		    set { SetValue( NotesTextProperty, value ); }
	    }
		private static void OnNotesTextPropertyChanged(DependencyObject source,
			DependencyPropertyChangedEventArgs e)
		{
			// Whatever you want to do when the text changes, like 
			// set flags to allow buttons to light up, etc.
		}
		private static object CoerceTextLineLimiter(DependencyObject d, object value)
		{
			string result = null;
			if (value != null)
			{
				string text = ((string)value);
				string[] lines = text.Split( '\n' );
				if (lines.Length <= MaxLineCount)
					result = text;
				else
				{
					StringBuilder obj = new StringBuilder();
					for (int index = 0; index < MaxLineCount; index++)
                        if (lines[index].Length > 0)
						    obj.AppendLine( lines[index] > MaxLineLength ? lines[index].Substring(0, MaxLineLength) : lines[index] );
					result = obj.ToString();
				}
			}
			return result;
		}
