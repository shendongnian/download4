        private void button3_Click(object sender, EventArgs e)
        {
            frmKasNew a = new frmKasNew();
            a.FormClosed += FormClosed;
            a.ShowDialog();
        }
    private void FormClosed(object sender, FormClosedEventArgs e)
    {
            SqlCommand sql = new SqlCommand("SELECT * FROM kas ORDER BY id_kas, tanggal DESC", koneksi.mykonek);
            koneksi.openkonek();
            SqlDataReader reader = sql.ExecuteReader();
            DataTable a = new DataTable();
            a.Load(reader);
            koneksi.closekonek();
            dgv.DataSource = a;
            dgv.Enabled = true;
        }
