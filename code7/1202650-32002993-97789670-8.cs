    class CountsDictionary : DynamicObject {
    
      readonly IDictionary<Int32, Int32> counts;
    
      public CountsDictionary(IDictionary<Int32, Int32> counts) {
        if (counts == null)
          throw new ArgumentNullException("counts");
        this.counts = counts;
      }
    
      public override Boolean TryGetMember(GetMemberBinder binder, out Object result) {
        Int32 value;
        if (binder.Name.StartsWith("CountType") && Int32.TryParse(binder.Name.Substring(9), NumberStyles.None, CultureInfo.InvariantCulture, out value) && value >= 0) {
          result = this.counts.ContainsKey(value) ? this.counts[value] : 0;
          return true;
        }
        result = 0;
        return false;
      }
    
    }
