    @if (!string.IsNullOrEmpty(item.PostContent) && item.PostContent.Length > 200)
    {
      <span>@Html.Raw(item.PostContent.Substring(0, 200))</span>
    }
    else
    {
      <span>@Html.Raw(item.PostContent)</span>
    }
