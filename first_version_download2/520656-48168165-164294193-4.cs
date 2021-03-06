                    Parallel.ForEach(Partitioner.Create(0, dt.Rows.Count),
                (range, state) =>
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        MigrationObject migSource = new MigrationObject(); 
                        migSource.PAN = dt.Rows[i]["CUST_ID"].ToString();
                        migSource.PinOffset = dt.Rows[i]["CODE"].ToString();
                        migSource.PinBlockNew = dt.Rows[i]["BLOCK_NEW"].ToString();
                        migSource.RelationshipNum = dt.Rows[i]["RELATIONSHIP_NUM"].ToString();
                        Console.WriteLine(@"PAN " + migSource.PAN + " Rel " + migSource.RelationshipNum
                                             + " for ranges : " + range.Item1 + " TO " + range.Item2);
                        sourceCollection.TryAdd(migSource);
                    }
                });
