    private async void button1_Click(object sender, EventArgs e) {
        var vari = await GetId();
        comboBox1.Items.Add(vari);
    }
    private async Task<string> GetId() {
        await Task.Delay(5000); //simulate long task
        string d = "Example";
        return d;
    }
