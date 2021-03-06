        // Returns true if postback is from current control or one of child controls of current control.
        // Returns false if postback is from any other controls (siblings or parents of the siblings) or if there is no postback.
        public bool IsPostBackFromCurrentControl()
        {
            return IsPostBackFromControlOrItsChildren(this);
        }
        // Returns true if postback is from the control or one of child controls of the control.
        // Returns false if postback is from any other controls (siblings, parents of the siblings or parent of current control) or if there is no postback.
        public bool IsPostBackFromControlOrItsChildren(Control ctl)
        {
            if (IsPostBack)
            {
                string eventTarget = Request["__EVENTTARGET"];
                if (eventTarget.StartsWith(ctl.UniqueID) || eventTarget.StartsWith(ctl.ClientID))
                    return true;
                else
                    return false;
            }
            return false;
        }
        // Returns true if postback is from the control.
        // Returns false if postback is from any other controls (siblings, parents of the siblings or parent or child of current control) or if there is no postback.
        public bool IsPostBackFromControl(Control ctl)
        {
            if (IsPostBack)
            {
                string eventTarget = Request["__EVENTTARGET"];
                if (eventTarget == ctl.UniqueID || eventTarget == ctl.ClientID)
                    return true;
                else
                    return false;
            }
            return false;
        }
