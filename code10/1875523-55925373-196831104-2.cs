    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication110
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                int[,] grid = new int[,] { { 1, 1, 1, 1, 1, 1 }, { 0, 0, 0, 0, 0, 0 }, { 2, 2, 2, 2, 2, 2 } };
                string xml = "<Data></Data>";
                XDocument doc = XDocument.Parse(xml);
                XElement data = doc.Root;
                for (int row = 0; row <= grid.GetUpperBound(0); row++ )
                {
                    XElement xRow = new XElement("Row");
                    data.Add(xRow);
                    for(int col = 0; col <= grid.GetUpperBound(1); col++)
                    {
                        XElement xCol = new XElement("Column", grid[row, col]);
                        xRow.Add(xCol);
                    }
                }
                doc.Save(FILENAME);
            }
        }
     
    }
