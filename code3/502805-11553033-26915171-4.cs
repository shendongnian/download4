    static void Main(string[] args)
        {
            var type = LiteDataType.String;
            var data1 = new LitePropertyData
            {
                Description = "LitePropertyData Description",
                DisplayEditUI = true,
                OwnerTab = 1,
                DisplayName = "LitePropertyData Display Name",
                FieldOrder = 2,
                IsRequired = true,
                Name = "LitePropertyData Name",
                IsModified = false,
                ParentPageID = 3,
                Type = type,
                Value = "LitePropertyData value"
            };
            var data2 = new LitePropertyData
            {
                Description = "LitePropertyData Description2",
                DisplayEditUI = false,
                OwnerTab = 4,
                DisplayName = "LitePropertyData Display Name2",
                FieldOrder = 5,
                IsRequired = false,
                Name = "LitePropertyData Name2",
                IsModified = false,
                ParentPageID = 6,
                Type = type,
                Value = "LitePropertyData value2"
            };
            var seo = new LiteSeoPageData 
            {
                Author = "Seo Author",
                Classification = "Seo class",
                CopyRight = "Seo copyright",
                Description = "Seo desc",
                Keywords = "Seo keywords",
                Title = "Seo Title"
            };
            var pageData = new LitePageData
            {
                Guid = Guid.NewGuid().ToString(),
                ID = 7,
                Name = "page data name",
                ParentID = null,
                Created = DateTime.Now,
                CreatedBy = "me",
                Changed = DateTime.UtcNow,
                LitePageTypeID = 9,
                Html = "this is not html",
                FriendlyName = "casper",
                IsDeleted = false,
                Properties = new List<LitePropertyData> { data1, data2 },
                Seo = seo
            };
            Save(@"C:\Users\Public\Documents\pageData.xml", pageData);
        }
        /// <summary>
        /// Saves the specified XML full file path.
        /// </summary>
        /// <param name="xmlFullFilePath">The XML full file path.</param>
        public static void Save(String xmlFullFilePath, LitePageData pageData)
        {
            //XDocument doc = XDocument.Load(xmlFullFilePath);
            var doc = new XDocument();
            XElement demoNode = GetXElementFromLitePageData(pageData);
            doc.Add(demoNode);
            ////demoNode.Name = "row";
            ////doc.Descendants("rows").Single().Add(demoNode);
            doc.Save(xmlFullFilePath);
        }
        public static XElement GetXElementFromLitePageData(LitePageData objectToSerialize)
        {
            var xmlSerializer = new XmlSerializer(typeof(LitePageData));
            var doc = new XDocument();
            using (XmlWriter xmlWriter = doc.CreateWriter())
            {
                xmlSerializer.Serialize(xmlWriter, objectToSerialize);
            }
            return doc.Root;
        }
