    // This class allows you to selectively suppress event handlers for controls.  You instantiate
    // the suppressor object with the control, and after that you can use it to suppress all events
    // or a single event.  If you try to suppress an event which has already been suppressed
    // it will be ignored.  Same with resuming; you can resume all events which were suppressed,
    // or a single one.  If you try to resume an un-suppressed event handler, it will be ignored.
    
    //cEventSuppressor _supButton1 = null;
    //private cEventSuppressor SupButton1 {
    //    get {
    //        if (_supButton1 == null) {
    //            _supButton1 = new cEventSuppressor(this.button1);
    //        }
    //        return _supButton1;
    //    }
    //}
    //private void button1_Click(object sender, EventArgs e) {
    //    MessageBox.Show("Clicked!");
    //}
    
    //private void button2_Click(object sender, EventArgs e) {
    //    SupButton1.Suppress("button1_Click");
    //}
    
    //private void button3_Click(object sender, EventArgs e) {
    //    SupButton1.Resume("button1_Click");
    //}
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    using System.Reflection;
    using System.Windows.Forms;
    using System.ComponentModel;
    
    namespace Crystal.Utilities {
        public class cEventSuppressor {
            Control _source;
            EventHandlerList _sourceEventHandlerList;
            FieldInfo _headFI;
            Dictionary<object, Delegate[]> suppressedHandlers = new Dictionary<object, Delegate[]>();
            PropertyInfo _sourceEventsInfo;
            Type _eventHandlerListType;
            Type _sourceType;
    
            public cEventSuppressor(Control control) {
                if (control == null)
                    throw new ArgumentNullException("control", "An instance of a control must be provided.");
    
                _source = control;
                _sourceType = _source.GetType();
                _sourceEventsInfo = _sourceType.GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic);
                _sourceEventHandlerList = (EventHandlerList)_sourceEventsInfo.GetValue(_source, null);
                _eventHandlerListType = _sourceEventHandlerList.GetType();
                _headFI = _eventHandlerListType.GetField("head", BindingFlags.Instance | BindingFlags.NonPublic);
            }
            private Dictionary<object, Delegate[]> BuildList() {
                Dictionary<object, Delegate[]> retval = new Dictionary<object, Delegate[]>();
                object head = _headFI.GetValue(_sourceEventHandlerList);
                if (head != null) {
                    Type listEntryType = head.GetType();
                    FieldInfo delegateFI = listEntryType.GetField("handler", BindingFlags.Instance | BindingFlags.NonPublic);
                    FieldInfo keyFI = listEntryType.GetField("key", BindingFlags.Instance | BindingFlags.NonPublic);
                    FieldInfo nextFI = listEntryType.GetField("next", BindingFlags.Instance | BindingFlags.NonPublic);
                    retval = BuildListWalk(retval, head, delegateFI, keyFI, nextFI);
                }
                return retval;
            }
    
            private Dictionary<object, Delegate[]> BuildListWalk(Dictionary<object, Delegate[]> dict,
                                        object entry, FieldInfo delegateFI, FieldInfo keyFI, FieldInfo nextFI) {
                if (entry != null) {
                    Delegate dele = (Delegate)delegateFI.GetValue(entry);
                    object key = keyFI.GetValue(entry);
                    object next = nextFI.GetValue(entry);
    
                    if (dele != null) {
                        Delegate[] listeners = dele.GetInvocationList();
                        if (listeners != null && listeners.Length > 0) {
                            dict.Add(key, listeners);
                        }
                    }
                    if (next != null) {
                        dict = BuildListWalk(dict, next, delegateFI, keyFI, nextFI);
                    }
                }
                return dict;
            }
            public void Resume() {
            }
            public void Resume(string pMethodName) {
                //if (_handlers == null)
                //    throw new ApplicationException("Events have not been suppressed.");
                Dictionary<object, Delegate[]> toRemove = new Dictionary<object, Delegate[]>();
    
                // goes through all handlers which have been suppressed.  If we are resuming,
                // all handlers, or if we find the matching handler, add it back to the
                // control's event handlers
                foreach (KeyValuePair<object, Delegate[]> pair in suppressedHandlers) {
    
                    for (int x = 0; x < pair.Value.Length; x++) {
    
                        string methodName = pair.Value[x].Method.Name;
                        if (pMethodName == null || methodName.Equals(pMethodName)) {
                            _sourceEventHandlerList.AddHandler(pair.Key, pair.Value[x]);
                            toRemove.Add(pair.Key, pair.Value);
                        }
                    }
                }
                // remove all un-suppressed handlers from the list of suppressed handlers
                foreach (KeyValuePair<object, Delegate[]> pair in toRemove) {
                    for (int x = 0; x < pair.Value.Length; x++) {
                        suppressedHandlers.Remove(pair.Key);
                    }
                }
                //_handlers = null;
            }
            public void Suppress() {
                Suppress(null);
            }
            public void Suppress(string pMethodName) {
                //if (_handlers != null)
                //    throw new ApplicationException("Events are already being suppressed.");
    
                Dictionary<object, Delegate[]> dict = BuildList();
    
                foreach (KeyValuePair<object, Delegate[]> pair in dict) {
                    for (int x = pair.Value.Length - 1; x >= 0; x--) {
                        //MethodInfo mi = pair.Value[x].Method;
                        //string s1 = mi.Name; // name of the method
                        //object o = pair.Value[x].Target;
                        // can use this to invoke method    pair.Value[x].DynamicInvoke
                        string methodName = pair.Value[x].Method.Name;
    
                        if (pMethodName == null || methodName.Equals(pMethodName)) {
                            _sourceEventHandlerList.RemoveHandler(pair.Key, pair.Value[x]);
                            suppressedHandlers.Add(pair.Key, pair.Value);
                        }
                    }
                }
            }
        } 
    }
