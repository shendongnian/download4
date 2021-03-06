    [HttpPost]
    public ActionResult Create(Parent parent)
    {
        if (ModelState.IsValid)
        {
            // The model is valid
            asset.Save();
            return RedirectToAction("Index", "Parent");
        }
        // the model is invalid => we must redisplay the same view.
        // but for this we obviously must fill the child collection
        // which is used in the dropdown list
        parent.ChildProperty = RehydrateTheSameWayYouDidInYourGetAction();
        return View(parent);
    }
