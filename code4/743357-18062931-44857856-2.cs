    public class LoopingPageView : PageView
    {
        protected override void OnPageChanged()
        {
            int pageIndex = Pages.IndexOf(ActivePage);
            if (pageIndex > 0 && pageIndex < Pages.Count - 1)
            {
                base.OnPageChanged();
            }
        }
    }
