using System;
using System.Drawing;
using System.Windows.Forms;
using ADB_Gui;

namespace ADB_Gui
{
    public partial class item : UserControl
    {
        public item()
        {
            InitializeComponent();
            TT.ForeColor = ForeColor;
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
        private void TT_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
            e.Graphics.DrawLine(new Pen(ForeColor), 0, e.Bounds.Height - 1, e.Bounds.Width, e.Bounds.Height - 1);
            e.Graphics.DrawLine(new Pen(ForeColor), 0, e.Bounds.Height - 25, e.Bounds.Width, e.Bounds.Height - 25);
            e.Graphics.DrawLine(new Pen(ForeColor), 0, e.Bounds.Height - 25, 0, e.Bounds.Height);
            e.Graphics.DrawLine(new Pen(ForeColor), e.Bounds.Width - 1, e.Bounds.Height - 25, e.Bounds.Width - 1, e.Bounds.Height);
        }
        private void item_ForeColorChanged(object sender, EventArgs e) => TT.ForeColor = ForeColor;
        private void back_Click(object sender, EventArgs e) => ADBGUI.comm = _command;
    }
}
