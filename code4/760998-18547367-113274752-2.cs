    var checkedRadio = new []{groupBox1, groupBox2}
                       .SelectMany(g=>g.Controls.OfType<RadioButton>()
                                                .Where(r=>r.Checked))
    // Print name
    foreach(var c in checkedRadio)
       System.Diagnostics.Debug.Print(c.Name);
