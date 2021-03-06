    var a = from page in rowData
            group page by new { 
                Subjectid = Page.PartitionKey.Substring(0,2),
                BookId = Page.PartitionKey.Substring(2,6),
                ChapterId = Page.PartitionKey.Substring(8)
            } into g
            select new {
                g.Key.SubjectId,
                g.Key.BookId,
                g.Key.ChapterId,
                Total = group.Sum(s => s.PageNumber)
            };
