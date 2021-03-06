    // POST: VRs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VR vR)
        {
            if (ModelState.IsValid)
            {
                vR.ModifiedBy = User.Identity.Name;
                vR.Modified = DateTime.Now;
                
                //Attach the instance so that we don't need to load it from the DB
                _context.MyVR.Attach(vR);
                //Specify the fields that should be updated.
                _context.Entry(vR).Property(x => x.ModifiedBy).IsModified = true;
                _context.Entry(vR).Property(x => x.Modified).IsModified = true;
                _context.Update(vR);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vR);
        }
