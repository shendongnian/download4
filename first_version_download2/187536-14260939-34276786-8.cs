    DataHolder holder = new DataHolder();
    foreach (var prepareElement in prepareElements)
    {
        // Do this with try get value to prevent errors
        DataUpdateActions[prepareElement.MappingName](s, holder);
        var fc = new FilesConverter.FilesConverter();           
        fc.SetCommonFiles(availabilityRequestFile, actualCurrentStateFile,
                               actualIpPlanFile, fileLoadDate); 
    }
