        private void rChkBoxB_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(rTxtBoxFormatID.Text) > 256)
            {
                DialogResult dialogresult = MessageBox.Show("B does not support numbering over a number!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dialogresult == DialogResult.OK)
                {
                    rChkBoxB.Checked = false;
                }
            }
        }
