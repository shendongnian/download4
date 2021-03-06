    var results = from res in dt.AsEnumerable()
                  group res by res.Field<string>(key)
                  into grp
                  orderby Convert.ToInt32(grp.Key)
                  select new
                      {
                         date = grp.Key,
                         sum = grp.Average(r => Convert.ToDouble(r.Field<string>(average))),
                         items = grp.ToList(),
                         sd = CalcSD(grp.Select(c => Convert.ToDouble(r.Field<string>(average))))
                      };
