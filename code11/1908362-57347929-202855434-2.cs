c#
private List<User> GetUsers()
{
	return new List<User>
	{
		new User { UserId = 1, FullName = "Test1"},
		new User { UserId = 2, FullName = "Test2"},
		new User { UserId = 3, FullName = "Test3"},
	};
}
private void BindUsers()
{
	var users = GetUsers(); // Get user from database
    // add your new item
	users.Add(new User { UserId = 4, FullName = "Test4"});
	cmb_username.ItemsSource = users;
	cmb_username.DisplayMemberPath = "FullName";
	cmb_username.SelectedValuePath = "UserID";
}
