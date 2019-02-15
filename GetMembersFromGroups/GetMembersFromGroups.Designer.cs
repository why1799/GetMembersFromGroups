namespace GetMembersFromGroups
{
    partial class GetMembersFromGroups
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.open = new System.Windows.Forms.Button();
            this.pathbox = new System.Windows.Forms.TextBox();
            this.intersectionlabel = new System.Windows.Forms.Label();
            this.intersectionbox = new System.Windows.Forms.TextBox();
            this.statuslabel1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.start = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.statuslabel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(244, 10);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(75, 23);
            this.open.TabIndex = 10;
            this.open.Text = "Обзор";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // pathbox
            // 
            this.pathbox.Location = new System.Drawing.Point(12, 13);
            this.pathbox.Name = "pathbox";
            this.pathbox.ReadOnly = true;
            this.pathbox.Size = new System.Drawing.Size(226, 20);
            this.pathbox.TabIndex = 9;
            this.pathbox.TabStop = false;
            // 
            // intersectionlabel
            // 
            this.intersectionlabel.AutoSize = true;
            this.intersectionlabel.Location = new System.Drawing.Point(9, 49);
            this.intersectionlabel.Name = "intersectionlabel";
            this.intersectionlabel.Size = new System.Drawing.Size(128, 13);
            this.intersectionlabel.TabIndex = 11;
            this.intersectionlabel.Text = "Пересечение в группах:";
            // 
            // intersectionbox
            // 
            this.intersectionbox.Location = new System.Drawing.Point(244, 46);
            this.intersectionbox.Name = "intersectionbox";
            this.intersectionbox.Size = new System.Drawing.Size(75, 20);
            this.intersectionbox.TabIndex = 12;
            this.intersectionbox.Text = "2";
            // 
            // statuslabel1
            // 
            this.statuslabel1.AutoSize = true;
            this.statuslabel1.Location = new System.Drawing.Point(96, 124);
            this.statuslabel1.Name = "statuslabel1";
            this.statuslabel1.Size = new System.Drawing.Size(0, 13);
            this.statuslabel1.TabIndex = 13;
            this.statuslabel1.TextChanged += new System.EventHandler(this.statuslabel1_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(14, 169);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(305, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(244, 72);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 15;
            this.start.Text = "Начать";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(227, 243);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(92, 23);
            this.logout.TabIndex = 16;
            this.logout.Text = "Разлогиниться";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // statuslabel2
            // 
            this.statuslabel2.AutoSize = true;
            this.statuslabel2.Location = new System.Drawing.Point(139, 143);
            this.statuslabel2.Name = "statuslabel2";
            this.statuslabel2.Size = new System.Drawing.Size(0, 13);
            this.statuslabel2.TabIndex = 17;
            this.statuslabel2.TextChanged += new System.EventHandler(this.statuslabel2_TextChanged);
            // 
            // GetMembersFromGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 282);
            this.Controls.Add(this.statuslabel2);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.start);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.statuslabel1);
            this.Controls.Add(this.intersectionbox);
            this.Controls.Add(this.intersectionlabel);
            this.Controls.Add(this.open);
            this.Controls.Add(this.pathbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GetMembersFromGroups";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GetMembersFromGroups";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.TextBox pathbox;
        private System.Windows.Forms.Label intersectionlabel;
        private System.Windows.Forms.TextBox intersectionbox;
        private System.Windows.Forms.Label statuslabel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Label statuslabel2;
    }
}

