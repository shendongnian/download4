     DataTable scoresTable = ScoresDataSet.Tables[0];                
                var result = scoresTable.AsEnumerable()
                    .Select(r => r.Field<string>("Grade")).Where(r => r != null);
                  
                var listOfGrades = result.ToList();
