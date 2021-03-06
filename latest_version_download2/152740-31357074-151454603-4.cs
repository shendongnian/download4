        const int edge = 16;
        class MouseFilter : NativeWindow {
            private Form form;
            public MouseFilter(Form form, Control child) {
                this.form = form;
                this.AssignHandle(child.Handle);
            }
            protected override void WndProc(ref Message m) {
                const int wmNcHitTest = 0x84;
                const int htTransparent = -1;
                if (m.Msg == wmNcHitTest) {
                    var pos = new Point(m.LParam.ToInt32());
                    if (pos.X < this.form.Left + edge ||
                        pos.Y < this.form.Top + edge||
                        pos.X > this.form.Right - edge ||
                        pos.Y > this.form.Bottom - edge) {
                        m.Result = new IntPtr(htTransparent);
                        return;
                    }
                }
                base.WndProc(ref m);
            }
        }
