    private string NOT_APPLICABLE = "N/A";
    . . .
    pvde.VarianceCraftworks = NOT_APPLICABLE;
    if (pvde.Week1PriceCraftworks.HasValue() && 
        pvde.Week2PriceCraftworks.HasValue())
    {
        pvde.VarianceCraftworks = pvde.Week2PriceCraftworks.SubtractDecimal(pvde.Week1PriceCraftworks);
    }
