    void zedGraphControl1_ZoomEvent(ZedGraph.ZedGraphControl z, ZedGraph.ZoomState oldState, ZedGraph.ZoomState newState)
    {
        GraphPane pane;
    
        using (var g = z.CreateGraphics())
            pane = z.MasterPane.FindPane(z.PointToClient(MousePosition));
    
        // The excludedGraphPane has to remain independant
        if (pane == null || pane == excludedGraphPane)
            return;
    
        foreach (var gp in z.MasterPane.PaneList)
        {
            if (gp == pane || gp == excludedGraphPane)
                continue;
    
            gp.XAxis.Scale.Min = pane.XAxis.Scale.Min;
            gp.XAxis.Scale.Max = pane.XAxis.Scale.Max;
            gp.AxisChange(); // Only necessary if one or more scale property is set to Auto.
        }
    
        z.Invalidate();
    }
