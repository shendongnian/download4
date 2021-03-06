private List<SelectListItem> _searchoptions;
// [BindProperty(SupportsGet = true)] // Remove this here
public SelectList SearchOptions { get; set; }
// Add a property to receive your selected value
[BindProperty(SupportsGet = true)]
public string BoundSearchField { get; set; }
public TestSelectModel()
{
    _searchoptions = new List<SelectListItem>();
    _searchoptions.Add(new SelectListItem("By Email", "By Email", true));
    _searchoptions.Add(new SelectListItem("By Request Name", "By Request Name", false));
}
public void OnGet()
{
    // Change "Key" to "Text"
    SearchOptions = new SelectList(_searchoptions, "Text", "Value", "By Email");
}
Then add ```name="BoundSearchField"``` to your .cshtml
<form>
    <div>
        <select name="BoundSearchField" asp-items="Model.SearchOptions">
            <option value="">Choose an search method</option>
        </select>
        <input type="submit" value="Filter" />
    </div>
</form>
