    var methodInfo = x.GetType().GetProperty(property);
                     
    manifestData.Manifest_Items = new ObservableCollection<ManifestItem>
    (
        temp.OrderBy(x =>
        {
            var s = methodInfo.GetValue(x);
            return s.Substring(0,1) + s.Substring(1).PadLeft(4, '0');
        }).ToList()
    );
