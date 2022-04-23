using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB_GUI
{
    public partial class Item : Form
    {
        public Item()
        {
            InitializeComponent();
        }
        #region properties
        private string _name;
        private string _description;
        [Category("props")]
        public string Tittle
        {
            get { return _name; }
            set { _name = value; label1.Text = value; }
        }

        [Category("props")]
        public string Command
        {
           get { return _description; }
           set { _description = value;}
        }
        #endregion
    }
}
