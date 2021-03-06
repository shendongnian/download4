    var query = from x in context.FirstTable
                where x.TestColumn == 5 
                          && x.SecondTable.SecondTestColumn == 3
                select new PresentationModel
                {
                    FirstTableColumn = x.Something,
                    SecondTableColumn = x.SecondTable.SomethingElse,
                    ThirdTableStuff = from y in x.SecondTable.ThirdTable
                                      select y.StillMore
                };
