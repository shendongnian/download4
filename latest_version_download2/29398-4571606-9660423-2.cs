    private Dictionary<string, TeamHours> BucketByProjectTask(Dictionary<string, TimeBooking> timebookings, Func<string, Task> getTaskKey)
    {
        …
        dict[getTaskKey(task)] = th;
        …
    }
