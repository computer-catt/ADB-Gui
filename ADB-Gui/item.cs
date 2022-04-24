using System;
using System.Drawing;
using System.Windows.Forms;

namespace ADB_GUI
{
    public partial class item : UserControl
    {
        public item()
        {
            InitializeComponent();
        }
        #region Properties
        private string _name;
        private string _command;
        public string Nam
        {
            get { return _name; }
            set { _name = value; back.Text = value; }
        }
        public string Command
        {
            get { return _command; }
            set { _command = value; TT.SetToolTip(back, value); }
        }
        #endregion
        private void close_Click(object sender, EventArgs e) => Parent.Controls.Remove(this);
        private void back_Click(object sender, EventArgs e) => new ADB_Gui.ADBGUI().adb(_command, true);
        private void TT_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
            e.Graphics.DrawLine(new Pen(Color.Lime), 0, e.Bounds.Height - 1, e.Bounds.Width, e.Bounds.Height - 1);
            e.Graphics.DrawLine(new Pen(Color.Lime), 0, e.Bounds.Height - 20, e.Bounds.Width, e.Bounds.Height - 20);
            e.Graphics.DrawLine(new Pen(Color.Lime), 0, e.Bounds.Height - 20, 0, e.Bounds.Height);
            e.Graphics.DrawLine(new Pen(Color.Lime), e.Bounds.Width - 1, e.Bounds.Height - 20, e.Bounds.Width - 1, e.Bounds.Height);
        }
    }
}
