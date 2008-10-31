namespace wiimoteremote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.box2 = new System.Windows.Forms.ComboBox();
            this.alabel = new System.Windows.Forms.Label();
            this.pluslabel = new System.Windows.Forms.Label();
            this.homepicture = new System.Windows.Forms.PictureBox();
            this.blabel = new System.Windows.Forms.Label();
            this.minuslabel = new System.Windows.Forms.Label();
            this.onelabel = new System.Windows.Forms.Label();
            this.twolabel = new System.Windows.Forms.Label();
            this.rightlabel = new System.Windows.Forms.Label();
            this.downlabel = new System.Windows.Forms.Label();
            this.uplabel = new System.Windows.Forms.Label();
            this.leftlabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.load = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.boxplus = new System.Windows.Forms.ComboBox();
            this.boxhome = new System.Windows.Forms.ComboBox();
            this.boxdown = new System.Windows.Forms.ComboBox();
            this.boxright = new System.Windows.Forms.ComboBox();
            this.boxup = new System.Windows.Forms.ComboBox();
            this.boxleft = new System.Windows.Forms.ComboBox();
            this.boxa = new System.Windows.Forms.ComboBox();
            this.boxb = new System.Windows.Forms.ComboBox();
            this.boxminus = new System.Windows.Forms.ComboBox();
            this.box1 = new System.Windows.Forms.ComboBox();
            this.connectbutton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.connectbox = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.lblBattery = new System.Windows.Forms.Label();
            this.pbBattery = new System.Windows.Forms.ProgressBar();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.homepicture)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(112, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 326);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // box2
            // 
            this.box2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box2.FormattingEnabled = true;
            this.box2.Location = new System.Drawing.Point(220, 281);
            this.box2.Name = "box2";
            this.box2.Size = new System.Drawing.Size(77, 21);
            this.box2.TabIndex = 10;
            this.box2.SelectedIndexChanged += new System.EventHandler(this.box2_SelectedIndexChanged);
            // 
            // alabel
            // 
            this.alabel.AutoSize = true;
            this.alabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alabel.Location = new System.Drawing.Point(1, 108);
            this.alabel.Name = "alabel";
            this.alabel.Size = new System.Drawing.Size(23, 24);
            this.alabel.TabIndex = 11;
            this.alabel.Text = "A";
            this.alabel.Click += new System.EventHandler(this.alabel_Click);
            // 
            // pluslabel
            // 
            this.pluslabel.AutoSize = true;
            this.pluslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pluslabel.Location = new System.Drawing.Point(197, 181);
            this.pluslabel.Name = "pluslabel";
            this.pluslabel.Size = new System.Drawing.Size(21, 24);
            this.pluslabel.TabIndex = 12;
            this.pluslabel.Text = "+";
            this.pluslabel.Click += new System.EventHandler(this.pluslabel_Click);
            // 
            // homepicture
            // 
            this.homepicture.Image = ((System.Drawing.Image)(resources.GetObject("homepicture.Image")));
            this.homepicture.Location = new System.Drawing.Point(192, 142);
            this.homepicture.Name = "homepicture";
            this.homepicture.Size = new System.Drawing.Size(26, 26);
            this.homepicture.TabIndex = 13;
            this.homepicture.TabStop = false;
            this.homepicture.Click += new System.EventHandler(this.homepicture_Click);
            // 
            // blabel
            // 
            this.blabel.AutoSize = true;
            this.blabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blabel.Location = new System.Drawing.Point(195, 111);
            this.blabel.Name = "blabel";
            this.blabel.Size = new System.Drawing.Size(22, 24);
            this.blabel.TabIndex = 14;
            this.blabel.Text = "B";
            this.blabel.Click += new System.EventHandler(this.blabel_Click);
            // 
            // minuslabel
            // 
            this.minuslabel.AutoSize = true;
            this.minuslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minuslabel.Location = new System.Drawing.Point(1, 158);
            this.minuslabel.Name = "minuslabel";
            this.minuslabel.Size = new System.Drawing.Size(26, 33);
            this.minuslabel.TabIndex = 15;
            this.minuslabel.Text = "-";
            this.minuslabel.Click += new System.EventHandler(this.minuslabel_Click);
            // 
            // onelabel
            // 
            this.onelabel.AutoSize = true;
            this.onelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onelabel.Location = new System.Drawing.Point(1, 250);
            this.onelabel.Name = "onelabel";
            this.onelabel.Size = new System.Drawing.Size(20, 24);
            this.onelabel.TabIndex = 16;
            this.onelabel.Text = "1";
            this.onelabel.Click += new System.EventHandler(this.onelabel_Click);
            // 
            // twolabel
            // 
            this.twolabel.AutoSize = true;
            this.twolabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twolabel.Location = new System.Drawing.Point(195, 281);
            this.twolabel.Name = "twolabel";
            this.twolabel.Size = new System.Drawing.Size(20, 24);
            this.twolabel.TabIndex = 17;
            this.twolabel.Text = "2";
            this.twolabel.Click += new System.EventHandler(this.twolabel_Click);
            // 
            // rightlabel
            // 
            this.rightlabel.AutoSize = true;
            this.rightlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightlabel.Location = new System.Drawing.Point(195, 49);
            this.rightlabel.Name = "rightlabel";
            this.rightlabel.Size = new System.Drawing.Size(21, 24);
            this.rightlabel.TabIndex = 18;
            this.rightlabel.Text = ">";
            this.rightlabel.Click += new System.EventHandler(this.rightlabel_Click);
            // 
            // downlabel
            // 
            this.downlabel.AutoSize = true;
            this.downlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downlabel.Location = new System.Drawing.Point(195, 76);
            this.downlabel.Name = "downlabel";
            this.downlabel.Size = new System.Drawing.Size(19, 24);
            this.downlabel.TabIndex = 19;
            this.downlabel.Text = "v";
            this.downlabel.Click += new System.EventHandler(this.downlabel_Click);
            // 
            // uplabel
            // 
            this.uplabel.AutoSize = true;
            this.uplabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uplabel.Location = new System.Drawing.Point(3, 36);
            this.uplabel.Name = "uplabel";
            this.uplabel.Size = new System.Drawing.Size(19, 24);
            this.uplabel.TabIndex = 20;
            this.uplabel.Text = "^";
            this.uplabel.Click += new System.EventHandler(this.uplabel_Click);
            // 
            // leftlabel
            // 
            this.leftlabel.AutoSize = true;
            this.leftlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftlabel.Location = new System.Drawing.Point(3, 63);
            this.leftlabel.Name = "leftlabel";
            this.leftlabel.Size = new System.Drawing.Size(21, 24);
            this.leftlabel.TabIndex = 21;
            this.leftlabel.Text = "<";
            this.leftlabel.Click += new System.EventHandler(this.leftlabel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(303, 19);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.load});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 17);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // save
            // 
            this.save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.save.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.save.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.save.MergeIndex = 0;
            this.save.Name = "save";
            this.save.Padding = new System.Windows.Forms.Padding(0);
            this.save.Size = new System.Drawing.Size(109, 20);
            this.save.Text = "Save";
            this.save.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.save.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.save.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // load
            // 
            this.load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.load.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.load.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.load.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.load.Name = "load";
            this.load.Padding = new System.Windows.Forms.Padding(0);
            this.load.Size = new System.Drawing.Size(109, 20);
            this.load.Text = "Load";
            this.load.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.load.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // boxplus
            // 
            this.boxplus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxplus.FormattingEnabled = true;
            this.boxplus.Location = new System.Drawing.Point(220, 184);
            this.boxplus.Name = "boxplus";
            this.boxplus.Size = new System.Drawing.Size(77, 21);
            this.boxplus.TabIndex = 24;
            this.boxplus.SelectedIndexChanged += new System.EventHandler(this.boxplus_SelectedIndexChanged);
            // 
            // boxhome
            // 
            this.boxhome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxhome.FormattingEnabled = true;
            this.boxhome.Location = new System.Drawing.Point(220, 144);
            this.boxhome.Name = "boxhome";
            this.boxhome.Size = new System.Drawing.Size(77, 21);
            this.boxhome.TabIndex = 25;
            this.boxhome.SelectedIndexChanged += new System.EventHandler(this.boxhome_SelectedIndexChanged);
            // 
            // boxdown
            // 
            this.boxdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxdown.FormattingEnabled = true;
            this.boxdown.Location = new System.Drawing.Point(220, 81);
            this.boxdown.Name = "boxdown";
            this.boxdown.Size = new System.Drawing.Size(77, 21);
            this.boxdown.TabIndex = 26;
            this.boxdown.SelectedIndexChanged += new System.EventHandler(this.boxdown_SelectedIndexChanged);
            // 
            // boxright
            // 
            this.boxright.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxright.FormattingEnabled = true;
            this.boxright.Location = new System.Drawing.Point(220, 52);
            this.boxright.Name = "boxright";
            this.boxright.Size = new System.Drawing.Size(77, 21);
            this.boxright.TabIndex = 27;
            this.boxright.SelectedIndexChanged += new System.EventHandler(this.boxright_SelectedIndexChanged);
            // 
            // boxup
            // 
            this.boxup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxup.FormattingEnabled = true;
            this.boxup.Location = new System.Drawing.Point(30, 36);
            this.boxup.Name = "boxup";
            this.boxup.Size = new System.Drawing.Size(77, 21);
            this.boxup.TabIndex = 28;
            this.boxup.SelectedIndexChanged += new System.EventHandler(this.boxup_SelectedIndexChanged);
            // 
            // boxleft
            // 
            this.boxleft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxleft.FormattingEnabled = true;
            this.boxleft.Location = new System.Drawing.Point(30, 66);
            this.boxleft.Name = "boxleft";
            this.boxleft.Size = new System.Drawing.Size(77, 21);
            this.boxleft.TabIndex = 29;
            this.boxleft.SelectedIndexChanged += new System.EventHandler(this.boxleft_SelectedIndexChanged);
            // 
            // boxa
            // 
            this.boxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxa.FormattingEnabled = true;
            this.boxa.Location = new System.Drawing.Point(30, 111);
            this.boxa.Name = "boxa";
            this.boxa.Size = new System.Drawing.Size(77, 21);
            this.boxa.TabIndex = 30;
            this.boxa.SelectedIndexChanged += new System.EventHandler(this.boxa_SelectedIndexChanged);
            // 
            // boxb
            // 
            this.boxb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxb.FormattingEnabled = true;
            this.boxb.Location = new System.Drawing.Point(220, 113);
            this.boxb.Name = "boxb";
            this.boxb.Size = new System.Drawing.Size(77, 21);
            this.boxb.TabIndex = 31;
            this.boxb.SelectedIndexChanged += new System.EventHandler(this.boxb_SelectedIndexChanged);
            // 
            // boxminus
            // 
            this.boxminus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxminus.FormattingEnabled = true;
            this.boxminus.Location = new System.Drawing.Point(32, 167);
            this.boxminus.Name = "boxminus";
            this.boxminus.Size = new System.Drawing.Size(77, 21);
            this.boxminus.TabIndex = 32;
            this.boxminus.SelectedIndexChanged += new System.EventHandler(this.boxminus_SelectedIndexChanged);
            // 
            // box1
            // 
            this.box1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box1.FormattingEnabled = true;
            this.box1.Location = new System.Drawing.Point(32, 250);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(77, 21);
            this.box1.TabIndex = 33;
            this.box1.SelectedIndexChanged += new System.EventHandler(this.box1_SelectedIndexChanged);
            // 
            // connectbutton
            // 
            this.connectbutton.Location = new System.Drawing.Point(139, 369);
            this.connectbutton.Name = "connectbutton";
            this.connectbutton.Size = new System.Drawing.Size(75, 23);
            this.connectbutton.TabIndex = 34;
            this.connectbutton.Text = "Connect";
            this.connectbutton.UseVisualStyleBackColor = true;
            this.connectbutton.Click += new System.EventHandler(this.connectbutton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 374);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Wiimote:";
            // 
            // connectbox
            // 
            this.connectbox.AutoSize = true;
            this.connectbox.Location = new System.Drawing.Point(57, 374);
            this.connectbox.Name = "connectbox";
            this.connectbox.Size = new System.Drawing.Size(76, 13);
            this.connectbox.TabIndex = 36;
            this.connectbox.Text = "not connected";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 321);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Custom:";
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(5, 337);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(100, 20);
            this.tb1.TabIndex = 38;
            // 
            // lblBattery
            // 
            this.lblBattery.AutoSize = true;
            this.lblBattery.Location = new System.Drawing.Point(256, 19);
            this.lblBattery.Name = "lblBattery";
            this.lblBattery.Size = new System.Drawing.Size(16, 13);
            this.lblBattery.TabIndex = 40;
            this.lblBattery.Text = "---";
            // 
            // pbBattery
            // 
            this.pbBattery.Location = new System.Drawing.Point(227, 5);
            this.pbBattery.Name = "pbBattery";
            this.pbBattery.Size = new System.Drawing.Size(71, 10);
            this.pbBattery.TabIndex = 41;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(178, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "Battery:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 400);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pbBattery);
            this.Controls.Add(this.lblBattery);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.connectbox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.connectbutton);
            this.Controls.Add(this.box1);
            this.Controls.Add(this.boxminus);
            this.Controls.Add(this.boxb);
            this.Controls.Add(this.boxa);
            this.Controls.Add(this.boxleft);
            this.Controls.Add(this.boxup);
            this.Controls.Add(this.boxright);
            this.Controls.Add(this.boxdown);
            this.Controls.Add(this.boxhome);
            this.Controls.Add(this.boxplus);
            this.Controls.Add(this.leftlabel);
            this.Controls.Add(this.uplabel);
            this.Controls.Add(this.downlabel);
            this.Controls.Add(this.rightlabel);
            this.Controls.Add(this.twolabel);
            this.Controls.Add(this.onelabel);
            this.Controls.Add(this.minuslabel);
            this.Controls.Add(this.blabel);
            this.Controls.Add(this.homepicture);
            this.Controls.Add(this.pluslabel);
            this.Controls.Add(this.alabel);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Wiimote Remote";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.homepicture)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox box2;
        private System.Windows.Forms.Label alabel;
        private System.Windows.Forms.Label pluslabel;
        private System.Windows.Forms.PictureBox homepicture;
        private System.Windows.Forms.Label blabel;
        private System.Windows.Forms.Label minuslabel;
        private System.Windows.Forms.Label onelabel;
        private System.Windows.Forms.Label twolabel;
        private System.Windows.Forms.Label rightlabel;
        private System.Windows.Forms.Label downlabel;
        private System.Windows.Forms.Label uplabel;
        private System.Windows.Forms.Label leftlabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem load;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem save;
        private System.Windows.Forms.ComboBox boxplus;
        private System.Windows.Forms.ComboBox boxhome;
        private System.Windows.Forms.ComboBox boxdown;
        private System.Windows.Forms.ComboBox boxright;
        private System.Windows.Forms.ComboBox boxup;
        private System.Windows.Forms.ComboBox boxleft;
        private System.Windows.Forms.ComboBox boxa;
        private System.Windows.Forms.ComboBox boxb;
        private System.Windows.Forms.ComboBox boxminus;
        private System.Windows.Forms.ComboBox box1;
        private System.Windows.Forms.Button connectbutton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label connectbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Label lblBattery;
        private System.Windows.Forms.ProgressBar pbBattery;
        private System.Windows.Forms.Label label13;


    }
}

