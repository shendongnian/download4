     public static object[] sql_Reader_To_Type(Type t, SqlDataReader r)
        {
            List<object> ret = new List<object>();
            while (r.Read())
            {
                FieldInfo[] f = t.GetFields();
                object o = Activator.CreateInstance(t);
                for (int i = 0; i < f.Length; i++)
                {
                    string thisType = f[i].FieldType.ToString();
                    switch (thisType)
                    {
                        case "System.String":
                            f[i].SetValue(o, Convert.ToString(r[f[i].Name]));
                            break;
                        case "System.Int16":
                            f[i].SetValue(o, Convert.ToInt16(r[f[i].Name]));
                            break;
                        case "System.Int32":
                            f[i].SetValue(o, Convert.ToInt32(r[f[i].Name]));
                            break;
                        case "System.Int64":
                            f[i].SetValue(o, Convert.ToInt64(r[f[i].Name]));
                            break;
                        case "System.Double":
                           double th;
                            if (r[f[i].Name] == null)
                            {
                                th = 0;
                            }
                            else
                            {
                                if (r[f[i].Name].GetType() == typeof(DBNull))
                                {
                                    th = 0;
                                }
                                else
                                {
                                    th = Convert.ToDouble(r[f[i].Name]);
                                }
                            }
                            try { f[i].SetValue(o, th); }
                            catch (Exception e1)
                            {
                                throw new Exception("can't convert " + f[i].Name + " to doube - value =" + th);
                            }
                            break;
                        case "System.Boolean":
                            f[i].SetValue(o, Convert.ToInt32(r[f[i].Name]) == 1 ? true : false);
                            break;
                        case "System.DateTime":
                            f[i].SetValue(o, Convert.ToDateTime(r[f[i].Name]));
                            break;
                        default:
                            throw new Exception("Missed data type in sql select ");
                    }
                }
                ret.Add(o);
            }
            return ret.ToArray();
        }
