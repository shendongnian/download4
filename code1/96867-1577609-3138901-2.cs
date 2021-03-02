    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Windows.Forms;
    namespace XXX.UI.Custom
    {
    /// <summary>
    /// A label which is capable of subscript.
    /// 
    /// Version: 1.
    /// Author: XXX.
    /// Date: 15/10/2009.
    /// Changes: Initial version.
    /// </summary>
    public class SubscriptLabel : Label
    {
        #region Vars
        // Vars.
        private char _subMark = '`';
        private SolidBrush _brush = new SolidBrush(Color.Black);
        private StringFormat _stringFormat = new StringFormat(StringFormat.GenericTypographic);
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the subscript marker.
        /// </summary>
        /// <value>The subscript marker.</value>
        [Description("Marker for start/end of subscript text."),
        Category("Appearance"),
        Browsable(true)]
        public char SubscriptMarker
        {
            get
            {
                return this._subMark;
            }
            set
            {
                _subMark = value;
                Invalidate();
            }
        }
        #endregion
        #region Methods
        #region Public
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptLabel"/> class.
        /// </summary>
        public SubscriptLabel()
        {
            // Setup text mode.
            _stringFormat.Alignment = StringAlignment.Near;
            _stringFormat.HotkeyPrefix = HotkeyPrefix.Show;
            _stringFormat.LineAlignment = StringAlignment.Near;
            _stringFormat.Trimming = StringTrimming.EllipsisCharacter;
            _stringFormat.HotkeyPrefix = HotkeyPrefix.None;
        }
        #endregion
        #region Private
        /// <summary>
        /// Measures the Y DSW.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <returns>The size.</returns>
        private RectangleF MeasureDSW(Graphics graphics, string text, 
            Font font)
        {
            // Vars.
            StringFormat stringFormat = new StringFormat(StringFormat.GenericDefault);
            RectangleF layoutRect = new RectangleF(0f, 0f, Width, Height);
            CharacterRange[] ranges = new CharacterRange[] { new CharacterRange(0, text.Length) };
            // Init.
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.HotkeyPrefix = HotkeyPrefix.Show;
            stringFormat.LineAlignment = StringAlignment.Near;
            stringFormat.Trimming = StringTrimming.EllipsisCharacter;
            stringFormat.HotkeyPrefix = HotkeyPrefix.None;
            stringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            stringFormat.SetMeasurableCharacterRanges(ranges);
            // Vars.
            Region[] regions = graphics.MeasureCharacterRanges(text, font, 
                layoutRect, stringFormat);
            // Loop around all the character ranges. 
            foreach (Region region in regions)
            {
                // Get the layout rectangle.
                layoutRect = region.GetBounds(graphics);
            }
            return layoutRect;
        }
        /// <summary>
        /// The pain method.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Ensure that we have some text to draw.
            if (!string.IsNullOrEmpty(Text))
            {
                // Init.
                float currentX = 0f;
                float currentY = 0f;
                string[] splittedText = Text.Split('`');
                // Setup graphics.
                e.Graphics.CompositingQuality = CompositingQuality.Default;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                // Loop around the splitted text.
                for (int i = 0; i < splittedText.Length; i++)
                {
                    // Vars.
                    int drawSubscript = i % 2;
                    // Are we to draw the subscript?
                    if (drawSubscript > 0)
                    {
                        DrawText(e.Graphics, ref currentX,
                            ref currentY, splittedText,
                            i, true);
                    }
                    else // Don't draw the subscript?
                    {
                        DrawText(e.Graphics, ref currentX,
                            ref currentY, splittedText,
                            i, false);
                    }
                }
            }
        }
        /// <summary>
        /// Draws the text onto the control.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="currentX">The current X.</param>
        /// <param name="currentY">The current Y.</param>
        /// <param name="splittedText">The splitted text.</param>
        /// <param name="i">The current text array position.</param>
        /// <param name="isSubScript">if set to <c>true</c> [is sub script].</param>
        private void DrawText(Graphics graphics, ref float currentX, 
            ref float currentY, string[] splittedText, 
            int i, bool isSubScript)
        {
            // Vars.
            string[] words = splittedText[i].Split(' ');
            // Loop around all the words.
            foreach (string word in words)
            {
                // Vars.
                string newWord = word + " ";
                // Are we rendering the subscript?
                if (isSubScript)
                {
                    // Remove the white space.
                    newWord = newWord.Trim(); 
                    // Do we want to remove the white space from the X coord?
                    if (splittedText.Length > 1)
                    {
                        // Init.
                        currentX -= MeasureDSW(graphics, " ",
                            Font).Right;
                    }
                }
                // Vars.
                float nextPosWord = MeasureDSW(graphics, newWord,
                    Font).Right;
                // Are we over the end of the label?
                if ((currentX + nextPosWord) > Width)
                {
                    // Add the Y coords.
                    currentY += MeasureDSW(graphics, newWord,
                        Font).Bottom;
                    // Reset the X coords.
                    currentX = 0;
                }
                // Loop around all the text characters.
                foreach (char textChar in word)
                {
                    // Vars.
                    float nextPos = MeasureDSW(graphics, textChar.ToString(),
                        Font).Right;
                    float newCurrentY = currentY;
                    // Is this for the sub script characters?
                    if (isSubScript)
                    {
                        newCurrentY += (5 * graphics.DpiY / 96);
                    }
                    // Draw onto the control.
                    graphics.DrawString(textChar.ToString(), Font,
                        _brush, new RectangleF(currentX,
                            newCurrentY, Width,
                            Height), _stringFormat);
                    // Add the size onto the X coords.
                    currentX += nextPos- (float)(2 * graphics.DpiX / 96);
                }
                if (!isSubScript)
                {
                    // Init.
                    currentX += MeasureDSW(graphics, " ",
                        Font).Right;
                }
            }
        }
        #endregion
        #endregion
    }
    }
