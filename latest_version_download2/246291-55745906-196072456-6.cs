    [HttpPut("api/[action]/{id}")]
    public async Task<IActionResult> PutProduct(Guid id, [FromBody]Product Product) {
        if (id != Product.Id) {
            ModelState.AddModelError("Id", "Invalid Id");
        }
        if(!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
    
        _context.Entry(Product).State = EntityState.Modified;
    
        try {
            await _context.SaveChangesAsync();
        } catch (DbUpdateConcurrencyException) {
            if (!ProductExists(id)) {
                return NotFound();
            } else {
                throw;
            }
        }
            
        return AcceptedAtAction("GetProduct", new { id = Product.Id, name = Product.Name }, Product);
    }
