    private void Button_Click_5(object sender, RoutedEventArgs e)
    {
        var move1 = new ObjectToMove();
        Animation_Path.Children.Add(move1);
        var storyBoardsToRun = new[] {"Storyboard1", "Storyboard2"};
        storyBoardsToRun 
            .Select(sbName => FindResource(sbName) as Storyboard)
            .ForEach(async sb => await sb.BeginAsync(move1));
    }
    public static Task BeginAsync(this Storyboard sb, FrameworkContentElement element)
    {
        var source = new TaskCompletionSource<object>();
        timeline.Completed += delegate
        {
            source.SetResult(null);
        };
        sb.Begin(element);
        return source.Task;
    }
