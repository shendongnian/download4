    Protected Sub Page_Load(sender As Object, e As EventArgs)
        If Not IsPostBack Then
            Dim users = Membership.GetAllUsers()
            UserName.DataSource = users
            UserName.DataBind()
        End If
    End Sub
