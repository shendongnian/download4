    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class PictureBoxEx : PictureBox {
        protected override void OnPaintBackground(PaintEventArgs e) {
            base.OnPaintBackground(e);
            var index = this.Parent.Controls.GetChildIndex(this); 
            while (++index < this.Parent.Controls.Count) {
                var ctl = this.Parent.Controls[index] as PictureBox;
                if (ctl == null) continue;
                var clip = ctl.RectangleToClient(this.RectangleToScreen(this.DisplayRectangle));
                clip.Intersect(ctl.DisplayRectangle);
                if (clip.Width == 0 || clip.Height == 0) continue;
                var save = e.Graphics.Save();
                e.Graphics.TranslateTransform(ctl.Left - this.Left, ctl.Top - this.Top);
                using (var rgn = new Region(clip)) {
                    e.Graphics.Clip = rgn;
                    InvokePaintBackground(ctl, e);
                    InvokePaint(ctl, e);
                }
                e.Graphics.Restore(save);
            }               
        }
    }
