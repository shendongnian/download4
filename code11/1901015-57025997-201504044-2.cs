        int triesInteger = 0;
        int randomnum = new Random().Next(0, 10);
        private void button3_Click(object sender, EventArgs e)
        {
            int guessInteger;
            if (int.TryParse(textBoxcommanf.Text, out guessInteger))
            {
                if (guessInteger < randomnum)
                {
                    triesInteger++;
                    answerLabel.Text = "You are too low";
                    numTriesLabel.Text = "" + triesInteger;
                }
                if (guessInteger > randomnum)
                {
                    triesInteger++;
                    answerLabel.Text = "You are too high";
                    numTriesLabel.Text = "" + triesInteger;
                }
                if (guessInteger == randomnum)
                {
                    triesInteger++;
                    answerLabel.Text = "Correct, Way to go!";
                    numTriesLabel.Text = "" + triesInteger;
                }
            }
            else
            {
                answerLabel.Text = "Number is invalid";
            }
        }
    
