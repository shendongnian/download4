    protected void AssignButton_Click(object sender, EventArgs e)
    {
        List<string> membersIdList = new List<string>();
        List<Missions> missionsList = null;
        string selectedMembersName = SelectedMembersDetailsGet(membersIdList, ref missionsList); 
    
        //Here membersIdList count is "1" & missionsList count is "0"                      
    }
    
    private string SelectedMembersDetailsGet(List<string> membersIdList, ref List<Missions> missionsList)
    {
        string selectedMembersName = string.Empty;
        IEnumerable<Missions> commonMissionsList = null;
    
        membersIdList.Add("XYZ");
    
        commonMissionsList = MissionsGet();  //Returns 4 records
    
        if (commonMissionsList != null)
        {
            missionsList = commonMissionsList.ToList(); 
        }
        return selectedMembersName;
    }
