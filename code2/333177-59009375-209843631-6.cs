        /// <summary>
        /// Executes asynchronously, on a thread pool thread.
        /// </summary>
        public static void BeginInvokeIfRequired<T>(this T c, Action<T> action) where T : Control
        {
            if (c.InvokeRequired)
                c.BeginInvoke(new Action(() => { action(c); }));
            else
                action(c);
        }
