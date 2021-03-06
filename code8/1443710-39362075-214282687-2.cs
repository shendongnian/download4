`
//...
DataTable dt = objTipoLicencia.DevolverListaTipoLicencia(String.Empty, String.Empty);
System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
Dictionary<string, object> row;
            
foreach (DataRow dr in dt.Rows)
{
    row = new Dictionary<string, object>();
    foreach (DataColumn col in dt.Columns)
    {
        row.Add(col.ColumnName, dr[col]);
    }
    rows.Add(row);
}
return serializer.Serialize(rows);
`
But make it sure that the DataTable (dt) populate with some data.
