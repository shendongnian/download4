                        int footerHeight = 30;
                        Bitmap bitmapImg = new Bitmap(img);
                        Bitmap bitmapComment = new Bitmap(img.Width, footerHeight);
                        Bitmap bitmapNewImage = new Bitmap(img.Width, img.Height + footerHeight);
                        Graphics graphicImage = Graphics.FromImage(bitmapNewImage);
                        graphicImage.Clear(Color.White);
                        graphicImage.DrawImage(bitmapImg, new Point(0, 0));
                        graphicImage.DrawImage(bitmapComment, new Point(bitmapComment.Width, 0));
                        graphicImage.DrawString(doc.txtComment, new Font("Arial", 15), new SolidBrush(Color.Black), 0, bitmapImg.Height + footerHeight / 6);
                        bitmapNewImage.Save(DocPath);
                        bitmapImg.Dispose();
                        bitmapComment.Dispose();
                        bitmapNewImage.Dispose();
