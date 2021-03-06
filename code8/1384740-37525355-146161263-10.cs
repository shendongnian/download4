    public async Task<MerchantViewModel> Get(
        Expression<Func<MerchantViewModel, bool>> predicate)
    {
        var domainMerchant = this._repository.GetItemAsync(
            predicate.CastParameter<MerchantViewModel, Merchant>());
    }
