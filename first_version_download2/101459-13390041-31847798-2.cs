              Panel pnlMsgBody =(Panel)gvwStuMsgBoard.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("pnlMsgBody");
		if(pnlMsgBody.Visible == false)
		{
			pnlMsgBody.Visible = true;
		}
		else
		{
			pnlMsgBody.Visible = false;
		}
	}
