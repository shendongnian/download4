    private List<Reminder> _activeReminders; // A list of reminders
    void TimerLoop(object s, ElapsedEventArgs e)
    {
        lock(_activeReminders) 
        {
            var now = DateTime.Now;
            foreach(var reminder in _activeReminders)
            {
                if(now.CompareTo(reminder.Alarm) >= 0 && !reminder.IsDismissed)
                {
                    MessageBox.Show(reminder.Message);
                    reminder.IsDismissed = true;
                }
            }
        }
    }
