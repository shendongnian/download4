    //Select the line from it's number
    richTextBox.GetFirstCharIndexFromLine(lineNumber);
    richTextBox.Select(startIndex, length);
    //Set the selected text for and background color
    richTextBox.SelectionColor = System.Drawing.Color.White;
    richTextBox.SelectionBackColor= System.Drawing.Color.Blue;
