    public async Task BtnSetLocationClickedAsync(object sender, EventArgs args)
    {
        if(UsernameEntry.Text == "Your Default UserName" && PasswordEntry.Text=="Your Default PassWord")
        {
             //Navigate your page
        }
        else
        {
            await DisplayAlert("Error", "Invalid Credential", "Ok");
        }
    }
