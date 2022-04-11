namespace ADB_simplifier
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bs = new System.Windows.Forms.Button();
            this.scriptyB = new System.Windows.Forms.Button();
            this.db = new System.Windows.Forms.Button();
            this.script = new System.Windows.Forms.RichTextBox();
            this.close = new System.Windows.Forms.Button();
            this.drag = new System.Windows.Forms.Panel();
            this.ds = new System.Windows.Forms.ComboBox();
            this.app = new System.Windows.Forms.Button();
            this.bs2 = new System.Windows.Forms.Button();
            this.bs3 = new System.Windows.Forms.Button();
            this.bs4 = new System.Windows.Forms.Button();
            this.bs5 = new System.Windows.Forms.Button();
            this.cldb = new System.Windows.Forms.Button();
            this.cl = new System.Windows.Forms.TextBox();
            this.cover = new System.Windows.Forms.Button();
            this.sc = new System.Windows.Forms.Timer(this.components);
            this.instant = new System.Windows.Forms.Button();
            this.dababy = new System.Windows.Forms.Button();
            this.sw = new System.Windows.Forms.Panel();
            this.textboxbackround = new System.Windows.Forms.Button();
            this.settext = new System.Windows.Forms.TextBox();
            this.bc = new System.Windows.Forms.Button();
            this.mount = new System.Windows.Forms.Button();
            this.percent = new System.Windows.Forms.Label();
            this.appdrawer = new System.Windows.Forms.Panel();
            this.la = new System.Windows.Forms.Label();
            this.drawe = new System.Windows.Forms.Button();
            this.drawp = new System.Windows.Forms.Panel();
            this.draw = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bcoverdraw = new System.Windows.Forms.Button();
            this.appdrawercover = new System.Windows.Forms.Button();
            this.apppop = new System.Windows.Forms.Timer(this.components);
            this.drag.SuspendLayout();
            this.sw.SuspendLayout();
            this.appdrawer.SuspendLayout();
            this.drawp.SuspendLayout();
            this.SuspendLayout();
            // 
            // bs
            // 
            this.bs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bs.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bs.Location = new System.Drawing.Point(12, 31);
            this.bs.Name = "bs";
            this.bs.Size = new System.Drawing.Size(90, 27);
            this.bs.TabIndex = 0;
            this.bs.Text = "list devices";
            this.bs.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bs.UseVisualStyleBackColor = true;
            this.bs.Click += new System.EventHandler(this.bs_Click);
            // 
            // scriptyB
            // 
            this.scriptyB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scriptyB.Location = new System.Drawing.Point(11, 64);
            this.scriptyB.Name = "scriptyB";
            this.scriptyB.Size = new System.Drawing.Size(776, 330);
            this.scriptyB.TabIndex = 1;
            this.scriptyB.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.scriptyB.UseVisualStyleBackColor = true;
            // 
            // db
            // 
            this.db.Enabled = false;
            this.db.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.db.Location = new System.Drawing.Point(0, 0);
            this.db.Name = "db";
            this.db.Size = new System.Drawing.Size(800, 25);
            this.db.TabIndex = 0;
            this.db.UseVisualStyleBackColor = true;
            // 
            // script
            // 
            this.script.BackColor = System.Drawing.Color.Black;
            this.script.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.script.ForeColor = System.Drawing.Color.Lime;
            this.script.Location = new System.Drawing.Point(12, 65);
            this.script.Name = "script";
            this.script.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.script.Size = new System.Drawing.Size(774, 327);
            this.script.TabIndex = 2;
            this.script.Text = "";
            // 
            // close
            // 
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.ForeColor = System.Drawing.Color.Red;
            this.close.Location = new System.Drawing.Point(766, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(34, 25);
            this.close.TabIndex = 3;
            this.close.Text = "X";
            this.close.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.button1_Click);
            // 
            // drag
            // 
            this.drag.Controls.Add(this.ds);
            this.drag.Controls.Add(this.app);
            this.drag.Location = new System.Drawing.Point(1, 1);
            this.drag.Name = "drag";
            this.drag.Size = new System.Drawing.Size(764, 21);
            this.drag.TabIndex = 4;
            this.drag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.drag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.drag.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // ds
            // 
            this.ds.BackColor = System.Drawing.Color.Black;
            this.ds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ds.ForeColor = System.Drawing.Color.Lime;
            this.ds.FormattingEnabled = true;
            this.ds.Location = new System.Drawing.Point(-1, -1);
            this.ds.Name = "ds";
            this.ds.Size = new System.Drawing.Size(174, 24);
            this.ds.TabIndex = 11;
            // 
            // app
            // 
            this.app.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.app.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.app.Location = new System.Drawing.Point(737, -2);
            this.app.Name = "app";
            this.app.Size = new System.Drawing.Size(28, 25);
            this.app.TabIndex = 11;
            this.app.Text = "=";
            this.app.UseVisualStyleBackColor = true;
            this.app.Click += new System.EventHandler(this.app_Click);
            // 
            // bs2
            // 
            this.bs2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bs2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bs2.Location = new System.Drawing.Point(108, 31);
            this.bs2.Name = "bs2";
            this.bs2.Size = new System.Drawing.Size(63, 27);
            this.bs2.TabIndex = 0;
            this.bs2.Text = "reboot";
            this.bs2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bs2.UseVisualStyleBackColor = true;
            this.bs2.Click += new System.EventHandler(this.bs2_Click);
            // 
            // bs3
            // 
            this.bs3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bs3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bs3.Location = new System.Drawing.Point(177, 31);
            this.bs3.Name = "bs3";
            this.bs3.Size = new System.Drawing.Size(84, 27);
            this.bs3.TabIndex = 0;
            this.bs3.Text = "install apk";
            this.bs3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bs3.UseVisualStyleBackColor = true;
            this.bs3.Click += new System.EventHandler(this.bs3_Click);
            // 
            // bs4
            // 
            this.bs4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bs4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bs4.Location = new System.Drawing.Point(267, 31);
            this.bs4.Name = "bs4";
            this.bs4.Size = new System.Drawing.Size(119, 27);
            this.bs4.TabIndex = 0;
            this.bs4.Text = "connect via wifi";
            this.bs4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bs4.UseVisualStyleBackColor = true;
            this.bs4.Click += new System.EventHandler(this.bs4_Click);
            // 
            // bs5
            // 
            this.bs5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bs5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bs5.Location = new System.Drawing.Point(392, 31);
            this.bs5.Name = "bs5";
            this.bs5.Size = new System.Drawing.Size(106, 27);
            this.bs5.TabIndex = 0;
            this.bs5.Text = "disconnect all";
            this.bs5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bs5.UseVisualStyleBackColor = true;
            this.bs5.Click += new System.EventHandler(this.bs5_Click);
            // 
            // cldb
            // 
            this.cldb.Enabled = false;
            this.cldb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cldb.Location = new System.Drawing.Point(10, 398);
            this.cldb.Name = "cldb";
            this.cldb.Size = new System.Drawing.Size(777, 42);
            this.cldb.TabIndex = 5;
            this.cldb.UseVisualStyleBackColor = true;
            // 
            // cl
            // 
            this.cl.BackColor = System.Drawing.Color.Black;
            this.cl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cl.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cl.ForeColor = System.Drawing.Color.Lime;
            this.cl.Location = new System.Drawing.Point(12, 400);
            this.cl.Name = "cl";
            this.cl.Size = new System.Drawing.Size(773, 38);
            this.cl.TabIndex = 6;
            this.cl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cl_KeyDown);
            // 
            // cover
            // 
            this.cover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cover.Enabled = false;
            this.cover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cover.Location = new System.Drawing.Point(0, 0);
            this.cover.Name = "cover";
            this.cover.Size = new System.Drawing.Size(1129, 634);
            this.cover.TabIndex = 7;
            this.cover.Text = "button1";
            this.cover.UseVisualStyleBackColor = true;
            // 
            // sc
            // 
            this.sc.Enabled = true;
            this.sc.Interval = 1000;
            this.sc.Tick += new System.EventHandler(this.sc_Tick);
            // 
            // instant
            // 
            this.instant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.instant.Location = new System.Drawing.Point(0, 0);
            this.instant.Name = "instant";
            this.instant.Size = new System.Drawing.Size(71, 27);
            this.instant.TabIndex = 8;
            this.instant.Text = "set text";
            this.instant.UseVisualStyleBackColor = true;
            this.instant.Click += new System.EventHandler(this.instant_Click);
            // 
            // dababy
            // 
            this.dababy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dababy.Location = new System.Drawing.Point(0, 0);
            this.dababy.Name = "dababy";
            this.dababy.Size = new System.Drawing.Size(71, 27);
            this.dababy.TabIndex = 8;
            this.dababy.Text = "live text";
            this.dababy.UseVisualStyleBackColor = true;
            this.dababy.Click += new System.EventHandler(this.dababyc);
            // 
            // sw
            // 
            this.sw.Controls.Add(this.dababy);
            this.sw.Controls.Add(this.instant);
            this.sw.Location = new System.Drawing.Point(717, 31);
            this.sw.Name = "sw";
            this.sw.Size = new System.Drawing.Size(71, 27);
            this.sw.TabIndex = 9;
            // 
            // textboxbackround
            // 
            this.textboxbackround.Enabled = false;
            this.textboxbackround.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textboxbackround.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxbackround.Location = new System.Drawing.Point(595, 31);
            this.textboxbackround.Name = "textboxbackround";
            this.textboxbackround.Size = new System.Drawing.Size(123, 27);
            this.textboxbackround.TabIndex = 0;
            this.textboxbackround.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.textboxbackround.UseVisualStyleBackColor = true;
            this.textboxbackround.Click += new System.EventHandler(this.bs5_Click);
            // 
            // settext
            // 
            this.settext.BackColor = System.Drawing.Color.Black;
            this.settext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.settext.ForeColor = System.Drawing.Color.Lime;
            this.settext.Location = new System.Drawing.Point(598, 37);
            this.settext.Name = "settext";
            this.settext.Size = new System.Drawing.Size(114, 15);
            this.settext.TabIndex = 10;
            this.settext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.settext_KeyDown);
            // 
            // bc
            // 
            this.bc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bc.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bc.Location = new System.Drawing.Point(152, 0);
            this.bc.Name = "bc";
            this.bc.Size = new System.Drawing.Size(28, 25);
            this.bc.TabIndex = 11;
            this.bc.UseVisualStyleBackColor = true;
            this.bc.Click += new System.EventHandler(this.percent_Click);
            // 
            // mount
            // 
            this.mount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mount.Location = new System.Drawing.Point(504, 31);
            this.mount.Name = "mount";
            this.mount.Size = new System.Drawing.Size(75, 26);
            this.mount.TabIndex = 12;
            this.mount.Text = "Mount";
            this.mount.UseVisualStyleBackColor = true;
            this.mount.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // percent
            // 
            this.percent.AutoSize = true;
            this.percent.BackColor = System.Drawing.Color.Transparent;
            this.percent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.percent.Location = new System.Drawing.Point(153, 4);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(21, 16);
            this.percent.TabIndex = 13;
            this.percent.Text = "69";
            this.percent.Click += new System.EventHandler(this.percent_Click);
            // 
            // appdrawer
            // 
            this.appdrawer.Controls.Add(this.la);
            this.appdrawer.Controls.Add(this.drawe);
            this.appdrawer.Controls.Add(this.drawp);
            this.appdrawer.Controls.Add(this.button2);
            this.appdrawer.Controls.Add(this.button1);
            this.appdrawer.Controls.Add(this.bcoverdraw);
            this.appdrawer.Controls.Add(this.appdrawercover);
            this.appdrawer.Location = new System.Drawing.Point(256, 101);
            this.appdrawer.Name = "appdrawer";
            this.appdrawer.Size = new System.Drawing.Size(306, 267);
            this.appdrawer.TabIndex = 14;
            this.appdrawer.Visible = false;
            // 
            // la
            // 
            this.la.AutoSize = true;
            this.la.Location = new System.Drawing.Point(3, 4);
            this.la.Name = "la";
            this.la.Size = new System.Drawing.Size(56, 16);
            this.la.TabIndex = 16;
            this.la.Text = "running: ";
            // 
            // drawe
            // 
            this.drawe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drawe.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawe.Location = new System.Drawing.Point(157, 49);
            this.drawe.Name = "drawe";
            this.drawe.Size = new System.Drawing.Size(28, 25);
            this.drawe.TabIndex = 11;
            this.drawe.UseVisualStyleBackColor = true;
            this.drawe.Click += new System.EventHandler(this.drawe_Click);
            // 
            // drawp
            // 
            this.drawp.Controls.Add(this.draw);
            this.drawp.Location = new System.Drawing.Point(30, 53);
            this.drawp.Name = "drawp";
            this.drawp.Size = new System.Drawing.Size(156, 17);
            this.drawp.TabIndex = 15;
            // 
            // draw
            // 
            this.draw.BackColor = System.Drawing.Color.Black;
            this.draw.ForeColor = System.Drawing.Color.Lime;
            this.draw.FormattingEnabled = true;
            this.draw.Location = new System.Drawing.Point(-4, -4);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(159, 24);
            this.draw.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(272, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 25);
            this.button2.TabIndex = 3;
            this.button2.Text = "X";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(306, 25);
            this.button1.TabIndex = 15;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // bcoverdraw
            // 
            this.bcoverdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bcoverdraw.Location = new System.Drawing.Point(25, 49);
            this.bcoverdraw.Name = "bcoverdraw";
            this.bcoverdraw.Size = new System.Drawing.Size(147, 25);
            this.bcoverdraw.TabIndex = 1;
            this.bcoverdraw.UseVisualStyleBackColor = true;
            // 
            // appdrawercover
            // 
            this.appdrawercover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appdrawercover.Enabled = false;
            this.appdrawercover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.appdrawercover.Location = new System.Drawing.Point(0, 0);
            this.appdrawercover.Name = "appdrawercover";
            this.appdrawercover.Size = new System.Drawing.Size(306, 267);
            this.appdrawercover.TabIndex = 0;
            this.appdrawercover.UseVisualStyleBackColor = true;
            // 
            // apppop
            // 
            this.apppop.Enabled = true;
            this.apppop.Interval = 5000;
            this.apppop.Tick += new System.EventHandler(this.apppop_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1129, 634);
            this.Controls.Add(this.appdrawer);
            this.Controls.Add(this.percent);
            this.Controls.Add(this.mount);
            this.Controls.Add(this.bc);
            this.Controls.Add(this.settext);
            this.Controls.Add(this.sw);
            this.Controls.Add(this.cl);
            this.Controls.Add(this.cldb);
            this.Controls.Add(this.drag);
            this.Controls.Add(this.close);
            this.Controls.Add(this.script);
            this.Controls.Add(this.scriptyB);
            this.Controls.Add(this.db);
            this.Controls.Add(this.bs4);
            this.Controls.Add(this.textboxbackround);
            this.Controls.Add(this.bs5);
            this.Controls.Add(this.bs3);
            this.Controls.Add(this.bs2);
            this.Controls.Add(this.bs);
            this.Controls.Add(this.cover);
            this.ForeColor = System.Drawing.Color.Lime;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.Text = "Form1";
            this.drag.ResumeLayout(false);
            this.sw.ResumeLayout(false);
            this.appdrawer.ResumeLayout(false);
            this.appdrawer.PerformLayout();
            this.drawp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bs;
        private System.Windows.Forms.Button scriptyB;
        private System.Windows.Forms.Button db;
        private System.Windows.Forms.RichTextBox script;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Panel drag;
        private System.Windows.Forms.Button bs2;
        private System.Windows.Forms.Button bs3;
        private System.Windows.Forms.Button bs4;
        private System.Windows.Forms.Button bs5;
        private System.Windows.Forms.Button cldb;
        private System.Windows.Forms.TextBox cl;
        private System.Windows.Forms.Button cover;
        private System.Windows.Forms.Timer sc;
        private System.Windows.Forms.Button instant;
        private System.Windows.Forms.Button dababy;
        private System.Windows.Forms.Panel sw;
        private System.Windows.Forms.Button textboxbackround;
        private System.Windows.Forms.TextBox settext;
        private System.Windows.Forms.ComboBox ds;
        private System.Windows.Forms.Button bc;
        private System.Windows.Forms.Button mount;
        private System.Windows.Forms.Label percent;
        private System.Windows.Forms.Button app;
        private System.Windows.Forms.Panel appdrawer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button appdrawercover;
        private System.Windows.Forms.Button drawe;
        private System.Windows.Forms.Panel drawp;
        private System.Windows.Forms.ComboBox draw;
        private System.Windows.Forms.Button bcoverdraw;
        private System.Windows.Forms.Timer apppop;
        private System.Windows.Forms.Label la;
    }
}

