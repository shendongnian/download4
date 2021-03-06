    public class FormMain : Form
    {
        // you might 'remember' the previous login name
        private string _previousUsername;
        
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            // create the login form
            using(var loginForm = new FormLogin())
            {
                // fillin the previous username
                loginForm.Username = _previousUsername;
                // this will block here, until the loginForm's DialogResult is set
                var result = loginForm.ShowDialog();
                // if the form was closed (other than pressing ok), cancel login
                if(result != DialogResult.OK)
                    return;
                // verify loginForm.Username, loginForm.Password
            }
        }
    }
    public class FormLogin : Form
    {
        // wrapper properties, it wraps the textbox.Text,
        // you don't want to expose the textbox directly, you might want to
        // use some other controls in future as editbox, which will change the contract 
        // for classes that are using this control/form, which causes modifying code 
        // on more than one place, (also affects testing again). This way you can keep it 
        // separated. Classes dependend on the FormLogin, shouldn't be dependend
        // on how it is presented.(UI)
        public string Username 
        { 
            get { return textboxUsername.Text; }
            set { textboxUsername.Text = value; }
        }
        public string Password 
        { 
            get { return textboxPassword.Text; }
            set { textboxPassword.Text = value; }
        }
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
