     namespace TE
    {
        public class High
        {
            public static void ChangeMyColor(RichTextBox rtb)
            {
                rtb.SelectionColor = Color.Black;
                rtb.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
            }
        }
    }
