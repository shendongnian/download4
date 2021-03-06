            //var doc = WordprocessingDocument.Open(@"C:\Users\rmontague\Desktop\TestDoc.docx", true);
            //AddWatermark(doc);
            //doc.MainDocumentPart.Document.Save();
            byte[] sourceBytes = File.ReadAllBytes(@"C:\Users\rmontague\Desktop\TestDoc.docx");
            MemoryStream inMemoryStream = new MemoryStream();
            inMemoryStream.Write(sourceBytes, 0, (int)sourceBytes.Length);
            var doc = WordprocessingDocument.Open(inMemoryStream, true);
            AddWatermark(doc);
            doc.MainDocumentPart.Document.Save();
            doc.Close();
            doc.Dispose();
            doc = null;
            using (FileStream fileStream = new FileStream(@"C:\Users\rmontague\Desktop\TestDoc.docx", System.IO.FileMode.Create))
            {
                inMemoryStream.WriteTo(fileStream);
            }
            inMemoryStream.Close();
            inMemoryStream.Dispose();
            inMemoryStream = null;
        }
