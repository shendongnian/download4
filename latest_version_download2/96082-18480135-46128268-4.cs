    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Logger
    {
        public partial class TraceView : Form
        {
            private Form _parent = null;
            
            private SynchronizationContext _context = SynchronizationContext.Current;
            private int _threadId = Thread.CurrentThread.ManagedThreadId;
    
            private object _lock = new Object(); // sync lock to protect _queue and _processing
            private Queue<Tuple<string, Color>> _queue = new Queue<Tuple<string, Color>>();
            private volatile bool _processing = false; // reentracy check flag
    
            public TraceView(Form parent)
            {
                _parent = parent;
                InitializeComponent();
            }
    
            public static TraceView Create(Form parent)
            {
                TraceView view = null;
                // create it on the parent window's thread
                parent.Invoke(new Action(() => {
                    view = new TraceView(parent);
                    view.Show(parent);
                }));
                return view;
            }
    
            private void DequeueMessages()
            {
                // make sure we are on the UI thread
                Debug.Assert(Thread.CurrentThread.ManagedThreadId == _threadId); 
                
                lock (_lock)
                {
                    // prevent re-entracy
                    if (_processing)
                        return;
                    // mark the beginning of processing
                    _processing = true;
                }
    
                // process pending messages
                for (; ; )
                {
                    Tuple<string, Color> msg = null;
    
                    lock (_lock)
                    {
                        if (!_queue.Any())
                        {
                            // mark the end of processing
                            _processing = false;
                            return;
                        }
                        msg = _queue.Dequeue();
                    }
    
                    if (this.Disposing || this.IsDisposed)
                    {
                        // do not just loose messages if the window is disposed
                        Trace.Write(msg.Item1); 
                    }
                    else
                    {
                        var selectionStart = _richTextBox.TextLength;
                        _richTextBox.AppendText(msg.Item1);
                        _richTextBox.Select(selectionStart, _richTextBox.TextLength);
                        _richTextBox.SelectionColor = msg.Item2;
                        _richTextBox.SelectionStart = _richTextBox.TextLength;
                        _richTextBox.ScrollToCaret();
                        _richTextBox.Refresh(); // redraw;
                        // DoEvents is required if logging from a tight loop, 
                        // to keep the UI responsive
                        Application.DoEvents(); 
                    }
                }
            }
    
            public void Write(string line, Color color)
            {
                lock (_lock)
                {
                    _queue.Enqueue(new Tuple<string, Color>(line, color));
                    // prevent re-entracy
                    if (_processing)
                        return; // DequeueMessages is already in progress
                }
    
                if (Thread.CurrentThread.ManagedThreadId == _threadId)
                    DequeueMessages();
                else
                    _context.Post((_) => 
                    { 
                        DequeueMessages();  
                    }, null);
            }
    
            public static TraceView CreateOnOwnThread()
            {
                TraceView view = null;
                using (var sync = new ManualResetEventSlim())
                {
                    // create it on its own thread
                    var thread = new Thread(() =>
                    {
                        SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
                        view = new TraceView(null);
                        view.Show();
                        sync.Set(); // ready Write calls
                        Application.Run(view); // view does Application.ExitThread() when closed
                        return;
                    });
    
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    sync.Wait();
                }
                return view;
            }
     
        }
    }
