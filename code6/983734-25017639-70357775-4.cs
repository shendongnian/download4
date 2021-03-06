    private CancellationTokenSource _cts;
    private async void TextBoxSearchText_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (_cts != null)
        _cts.Cancel();
      _cts = new CancellationTokenSource();
      ListBoxAllTexts.ItemsSource = await Task.Run(() => searchText(_cts.Token));
    }
    private List<TextList> searchText(CancellationToken token)
    {
      try
      {
        return oTextList.AsParallel().WithCancellation(token)
            .Where(item => Regex.IsMatch(item.EnglishText.ToString(), "\\b" + strSearchText.ToString().ToLower() + @"\w*", RegexOptions.IgnoreCase))
            .Select(item => new TextList
            {
              Id = item.Id,
              EnglishText = item.EnglishText
            })
            .ToList();
      }
      catch (OperationCanceledException)
      {
      }
    }
