        private void button1_Click(object sender, EventArgs e) {
            using (var bmp = new Bitmap(panel1.Width, panel1.Width)) {
                panel1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(@"c:\temp\test.png");
            }
        }
