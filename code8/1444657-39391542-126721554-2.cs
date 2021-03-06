	public partial class EditorWrapper : UserControl
	{
        // Your defined DependencyProperty
		public static readonly DependencyProperty SoundLengthProperty=DependencyProperty.Register("SoundLength",typeof(int),typeof(EditorWrapper),new PropertyMetadata(OnSoundLengthChanged));
		public TextWithSound TextSound
		{
			set
			{
				try
				{
					if(value.Text != null && value.Stream != null)
					{
						CdsEditorOverrides editorCtrl.LoadDocumentSetAsXmlString(value.Text);
						editorCtrl.GetAudioPlayer().LoadAudioFromStream(new StreamWrapper(value.Stream));
						editorCtrl.GetAudioPlayer().AudioStreamingComplete();
						
						// set the sound length (will automatically notify the binding)
						SoundLength=editorCtrl.GetAudioPlayer().GetPlaybackLength();
						
						Debug.WriteLine("TextSound updated");
					}
				}
				catch (Exception ex)
				{
					Debug.WriteLine("Error loading Text: " + ex.ToString());
					//don't throw in get/set
				}
			}
		}
        // The actual Property: gets/sets the value to the DependencyProperty
		public int SoundLength
		{
			get { return (int)GetValue(SoundLengthProperty); }
			private set { SetValue(SoundLengthProperty,value); }
		}
	}
