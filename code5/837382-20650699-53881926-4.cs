    protected override void Execute(NativeActivityContext context) {
      DataSet dataset = GetDataSet.Get(context);
      foreach(DataTable dt in dataset.Tables) {
        foreach(DataRow row in dt.Rows) {
          row["USER_COMMENT"] = ConvertNullToEmptyString(row["USER_COMMENT"]);
        }
      }
      TransformResult.Set(context, dataset);
    }
    private static object ConvertNullToEmptyString(object element) {
      if(String.IsNullOrEmpty(element.ToString())) {
        return "NO DATA";
      } else {
        return element;
      }
    }
