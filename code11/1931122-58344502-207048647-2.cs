string csv_file_path = @"pathToCsvFile";
//Assuming just one index for the column number to skip - zero based counting. 
//perhaps read from the AppConfig
int columnIndexToSkip = 2;
DataTable csvData = GetDataTabletFromCSVFile(csv_file_path, columnIndexToSkip);
2. Modify the function signature to take the extra int parameter
        private static DataTable GetDataTabletFromCSVFile(string csv_file_path, int columnIndexToSkip)
        {
3. Add the dummy column at that index
                            csvData.Rows.Add(fieldData);
                        }
                    }// end of while (!csvReader.EndOfData) loop
                    if (columnIndexToSkip >= 0)
                    {
                        csvData.Columns.Add("DUMMY").SetOrdinal(columnIndexToSkip);
                    }
I've not tested the import, but the updated csv file looks good to me.
