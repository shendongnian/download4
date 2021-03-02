    class ListViewToCSV
    {
        public static void ListViewToCSV(ListView listView, string filePath, bool includeHidden)
        {
            //make header srting
            StringBuilder result = new StringBuilder();
            WriteCSVRow(result, listView.Columns, i => includeHidden || listView.Columns[i].Width > 0, i => listView.Columns[i].Text);
            //export data rows
            foreach (var listItem in listView.Items)
            {
                WriteCSVRow(result, listView.Columns, i => includeHidden || listView.Columns[i].Width > 0, i => listItem.SubItems[i].Text);
            }
            File.WriteAllText(filePath, result.ToString());
        }
        private void WriteCSVRow(StringBuilder result, IList list, Func<int, bool> isColumnNeeded, Func<int, string> columnValue)
        {
            bool isFirstTime = true;
            for (int i = 0; i < list.Count; i++)
            {
                if (!isColumnNeeded(i))
                    continue;
                if (!isFirstTime)
                    result.Append(",");
                isFirstTime = false;
                result.Append(String.Format("\"{0}\"", columnValue(i)));
            }
            result.AppendLine();
        }
    }
