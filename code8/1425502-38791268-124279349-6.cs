        private int? Linesel(List<GraphicsPath> LineGroup)
        {
            for (int i =0; i < LineGroup.Count; i++)
            {
                Pen pen = new Pen(Color.Navy, 8);
                if (LineGroup[i].IsOutlineVisible(Latest, pen))
                {
                    return i;
                }
            }
            return null;
        }
    use it like:   
        var res = Linesel(....);
        if(!res.HasValue)
        {
            // problem
        }
        else
        {
            // ->   res.Value;
        }
