    public void SearchForWatiNOnGoogle()
    {
      using (var browser = new IE("http://www.google.com"))
      {
        browser.TextField(Find.ByName("q")).TypeText("WatiN");
        browser.Button(Find.ByName("btnG")).Click();
      
        bool contains = browser.ContainsText("WatiN");
      }
    }
