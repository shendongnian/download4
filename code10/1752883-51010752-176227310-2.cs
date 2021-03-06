        private List<Control> dynamicControls = new List<Control>();
        private void button1_Click_1(object sender, EventArgs e)
        {
            Label label = new Label();
            //...
            dynamicControls.Add(label);
            TextBox textbox = new TextBox();
            //...
            dynamicControls.Add(textbox);
            Button button = new Button();
            //...
            dynamicControls.Add(button);
        }
        public void RemoveDynamicControls()
        {
            if (dynamicControls.Count > 0)
            {
                var control = dynamicControls[0];
                if (panel1.Controls.Contains(control))
                {
                    dynamicControls.Remove(control);
                    panel1.Controls.Remove(control);
                }
            }
        }
