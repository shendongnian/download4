    private void LoadEditorTab()
        {
            var editor = new PcmEditorForm();
            var grid = new GridView();
            grid.width=editor.width
            grid.Anchor= AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            editor.Controls.Add(grid);
            tabEdit.Controls.Clear();
            editor.TopLevel = false;
            editor.Visible = true;
            editor.dock=DockStyle.Fill;  // Dock the editor
            tabEdit.Controls.Add(editor);
        }
