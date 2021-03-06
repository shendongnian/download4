        protected void StartSelection_Changed(Object sender, EventArgs e)
        {
            startCalendar.SelectedDate = new DateTime(startCalendar.SelectedDate.Year,
                startCalendar.SelectedDate.Month, startCalendar.SelectedDate.Day, 0, 0, 0);
    
            // c.f. http://www.mikepope.com/blog/AddComment.aspx?blogid=604
            int index = -1;
            index = startDates.IndexOf(startCalendar.SelectedDate);
            if (index >= 0)
            {  
                startDates.RemoveAt(index);
            }
            else
            {
                DateTime dateTime 
                    = new DateTime(startCalendar.SelectedDate.Year,
                        startCalendar.SelectedDate.Month, 
                            startCalendar.SelectedDate.Day, 0, 0, 0);
    
                startDates.Add(dateTime);
            }
    
            ViewState["StartDates"] = startDates;
            DisplaySelectedDates();
        }
