    if (facet is XmlSchemaLengthFacet)
    {
        handler.Length((XmlSchemaLengthFacet)facet); 
    } 
    else if (facet is XmlSchemaMinLengthFacet)
    {
        handler.MinLength((XmlSchemaMinLengthFacet)facet); 
    } 
    else if (facet is XmlSchemaMaxLengthFacet)
    {
        handler.MaxLength((XmlSchemaMaxLengthFacet)facet); 
    } 
    else
    {
        //Handle Error
    }
