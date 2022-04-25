namespace ADB_Gui
{
    partial class item
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.back = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.TT = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.Location = new System.Drawing.Point(0, 0);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(383, 30);
            this.back.TabIndex = 0;
            this.back.Text = "Name here";
            this.back.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TT.SetToolTip(this.back, "ass");
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(back_Click);
            // 
            // close
            // 
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.ForeColor = System.Drawing.Color.Red;
            this.close.Location = new System.Drawing.Point(353, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(30, 30);
            this.close.TabIndex = 1;
            this.close.Text = "x";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // TT
            // 
            this.TT.AutomaticDelay = 1000;
            this.TT.BackColor = System.Drawing.Color.Black;
            this.TT.ForeColor = this.ForeColor;
            this.TT.OwnerDraw = true;
            this.TT.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.TT_Draw);
            // 
            // item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.close);
            this.Controls.Add(this.back);
            this.ForeColor = System.Drawing.Color.Lime;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "item";
            this.Size = new System.Drawing.Size(383, 30);
            this.ForeColorChanged += new System.EventHandler(this.item_ForeColorChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.ToolTip TT;
    }
}
