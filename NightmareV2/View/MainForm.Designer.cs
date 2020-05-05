namespace NightmareV2.View
{
    partial class MainForm
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
            this.tlsMenu = new System.Windows.Forms.ToolStrip();
            this.btnCloseForm = new System.Windows.Forms.ToolStripButton();
            this.btnSkipForm = new System.Windows.Forms.ToolStripButton();
            this.tlsIco = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnKey1 = new System.Windows.Forms.Button();
            this.btnKey3 = new System.Windows.Forms.Button();
            this.btnKey2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.tlsMenu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsMenu
            // 
            this.tlsMenu.BackColor = System.Drawing.Color.Yellow;
            this.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCloseForm,
            this.btnSkipForm,
            this.tlsIco,
            this.toolStripLabel1});
            this.tlsMenu.Location = new System.Drawing.Point(0, 0);
            this.tlsMenu.Name = "tlsMenu";
            this.tlsMenu.Size = new System.Drawing.Size(1200, 25);
            this.tlsMenu.TabIndex = 2;
            this.tlsMenu.Text = "tls";
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCloseForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCloseForm.Image = global::NightmareV2.Properties.Resources.Exit;
            this.btnCloseForm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(23, 22);
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnSkipForm
            // 
            this.btnSkipForm.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSkipForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSkipForm.Image = global::NightmareV2.Properties.Resources.Skip;
            this.btnSkipForm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSkipForm.Name = "btnSkipForm";
            this.btnSkipForm.Size = new System.Drawing.Size(23, 22);
            this.btnSkipForm.Click += new System.EventHandler(this.btnSkipForm_Click);
            // 
            // tlsIco
            // 
            this.tlsIco.Image = global::NightmareV2.Properties.Resources.FromIco;
            this.tlsIco.Name = "tlsIco";
            this.tlsIco.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tlsIco.Size = new System.Drawing.Size(26, 22);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(149, 22);
            this.toolStripLabel1.Text = "Nightmare Realm (Replica)";
            // 
            // flowPanel
            // 
            this.flowPanel.BackColor = System.Drawing.Color.Transparent;
            this.flowPanel.BackgroundImage = global::NightmareV2.Properties.Resources.EmptyBlock;
            this.flowPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPanel.ForeColor = System.Drawing.Color.Transparent;
            this.flowPanel.Location = new System.Drawing.Point(340, 149);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(535, 535);
            this.flowPanel.TabIndex = 3;
            // 
            // btnKey1
            // 
            this.btnKey1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKey1.Enabled = false;
            this.btnKey1.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnKey1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey1.Location = new System.Drawing.Point(342, 41);
            this.btnKey1.Name = "btnKey1";
            this.btnKey1.Size = new System.Drawing.Size(100, 100);
            this.btnKey1.TabIndex = 4;
            this.btnKey1.UseVisualStyleBackColor = true;
            // 
            // btnKey3
            // 
            this.btnKey3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKey3.Enabled = false;
            this.btnKey3.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnKey3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey3.Location = new System.Drawing.Point(772, 41);
            this.btnKey3.Name = "btnKey3";
            this.btnKey3.Size = new System.Drawing.Size(100, 100);
            this.btnKey3.TabIndex = 5;
            this.btnKey3.UseVisualStyleBackColor = true;
            // 
            // btnKey2
            // 
            this.btnKey2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKey2.Enabled = false;
            this.btnKey2.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnKey2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey2.Location = new System.Drawing.Point(557, 41);
            this.btnKey2.Name = "btnKey2";
            this.btnKey2.Size = new System.Drawing.Size(100, 100);
            this.btnKey2.TabIndex = 6;
            this.btnKey2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btnRestart);
            this.flowLayoutPanel1.Controls.Add(this.btnInfo);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 669);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(170, 31);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // btnRestart
            // 
            this.btnRestart.BackgroundImage = global::NightmareV2.Properties.Resources.EmptyBlock;
            this.btnRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.ForeColor = System.Drawing.Color.White;
            this.btnRestart.Location = new System.Drawing.Point(3, 3);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 8;
            this.btnRestart.Text = "Рестарт";
            this.btnRestart.UseVisualStyleBackColor = false;
            // 
            // btnInfo
            // 
            this.btnInfo.BackgroundImage = global::NightmareV2.Properties.Resources.EmptyBlock;
            this.btnInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.btnInfo.ForeColor = System.Drawing.Color.White;
            this.btnInfo.Location = new System.Drawing.Point(84, 3);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(79, 23);
            this.btnInfo.TabIndex = 9;
            this.btnInfo.Text = "Справка";
            this.btnInfo.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NightmareV2.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1200, 712);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnKey2);
            this.Controls.Add(this.btnKey3);
            this.Controls.Add(this.btnKey1);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.tlsMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nightmare Replica";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tlsMenu.ResumeLayout(false);
            this.tlsMenu.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip tlsMenu;
        private System.Windows.Forms.ToolStripButton btnCloseForm;
        private System.Windows.Forms.ToolStripButton btnSkipForm;
        private System.Windows.Forms.ToolStripLabel tlsIco;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Button btnKey1;
        private System.Windows.Forms.Button btnKey3;
        private System.Windows.Forms.Button btnKey2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnInfo;
    }
}

