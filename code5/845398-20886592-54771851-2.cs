    void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!_task.IsCompleted
            && !_task.IsCanceled
            && !_task.IsFaulted)
        {
            e.Cancel = true;
            _cts.Cancel();
            _task.ContinueWith(t => Close());
        }
    }
