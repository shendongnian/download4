    double res;
    if(double.TryParse(tbPayment.Text, out res))
    {
        holDer = res - double.Parse(lblTotalPrice.Text);
        MessageBox.Show("Change: " + holDer.ToString());
    }
    else
    {
        MessageBox.Show("Input a correct format");
    }
