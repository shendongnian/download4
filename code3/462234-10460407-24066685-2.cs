    int numSelected = 0;
    foreach (ListItem li in chkselectedItems.Items)
    {
    if (li.Selected)
    {
    numSelected = numSelected + 1;
    }
    }
    Response.Write("Total Number Of CheckBoxes Selected:");
    Response.Write(numSelected);
