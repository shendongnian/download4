    private void btnCalc_Click(object sender, EventArgs e)
    {
        var Number = int.Parse(txtNum.Text); // To hold Number
        
        switch (Number)
        {
                case 1:
                  lblRoman.Text = "I";
                  break;
                case 2:
                  lblRoman.Text = "II";
                  break;
                case 3:
                  lblRoman.Text = "III";
                  break;
                case 4:
                  lblRoman.Text = "IV";
                  break;
                case 5:
                  lblRoman.Text = "V";
                  break;
                case 6:
                  lblRoman.Text = "VI";
                  break;
                case 7:
                  lblRoman.Text = "VII";
                  break;
                case 8:
                  lblRoman.Text = "VIII";
                  break;
                case 9:
                  lblRoman.Text = "IX";
                  break;
                case 10:
                  lblRoman.Text = "X";
                  break;
                default:
                  MessageBox.Show("Error: Invalid Input");
                  break;
        }
    }
