    public int GetLabelsSize(string text)
    {
        using (var g = lblResultKB.CreateGraphics()) {
           return g.MeasureString(text, lblResultKB.Font).Width + lblResultKB.Margin.Left + lblResultKB.Margin.Right;
        }
    }
