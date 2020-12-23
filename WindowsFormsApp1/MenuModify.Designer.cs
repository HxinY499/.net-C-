namespace WindowsFormsApp1
{
    partial class MenuModify
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
            this.menuPanel = new System.Windows.Forms.Panel();
            this.menuNameAddTB = new System.Windows.Forms.TextBox();
            this.menuPriceAddTB = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.warningNameMessage = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.warningPriceMessage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MenuAddBu = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.AutoScroll = true;
            this.menuPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuPanel.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuPanel.Location = new System.Drawing.Point(90, 147);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(1016, 728);
            this.menuPanel.TabIndex = 1;
            // 
            // menuNameAddTB
            // 
            this.menuNameAddTB.Location = new System.Drawing.Point(78, 38);
            this.menuNameAddTB.Margin = new System.Windows.Forms.Padding(4);
            this.menuNameAddTB.Name = "menuNameAddTB";
            this.menuNameAddTB.Size = new System.Drawing.Size(148, 28);
            this.menuNameAddTB.TabIndex = 2;
            this.menuNameAddTB.Click += new System.EventHandler(this.menuNameAddTB_Click);
            // 
            // menuPriceAddTB
            // 
            this.menuPriceAddTB.Location = new System.Drawing.Point(78, 117);
            this.menuPriceAddTB.Margin = new System.Windows.Forms.Padding(4);
            this.menuPriceAddTB.Name = "menuPriceAddTB";
            this.menuPriceAddTB.Size = new System.Drawing.Size(148, 28);
            this.menuPriceAddTB.TabIndex = 3;
            this.menuPriceAddTB.Click += new System.EventHandler(this.menuPriceAddTB_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.warningNameMessage);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.warningPriceMessage);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.MenuAddBu);
            this.panel1.Controls.Add(this.menuNameAddTB);
            this.panel1.Controls.Add(this.menuPriceAddTB);
            this.panel1.Location = new System.Drawing.Point(1398, 164);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 297);
            this.panel1.TabIndex = 4;
            // 
            // warningNameMessage
            // 
            this.warningNameMessage.AutoSize = true;
            this.warningNameMessage.ForeColor = System.Drawing.Color.Red;
            this.warningNameMessage.Location = new System.Drawing.Point(80, 80);
            this.warningNameMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.warningNameMessage.Name = "warningNameMessage";
            this.warningNameMessage.Size = new System.Drawing.Size(98, 18);
            this.warningNameMessage.TabIndex = 8;
            this.warningNameMessage.Text = "！不能为空";
            this.warningNameMessage.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "菜名：";
            // 
            // warningPriceMessage
            // 
            this.warningPriceMessage.AutoSize = true;
            this.warningPriceMessage.ForeColor = System.Drawing.Color.Red;
            this.warningPriceMessage.Location = new System.Drawing.Point(80, 162);
            this.warningPriceMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.warningPriceMessage.Name = "warningPriceMessage";
            this.warningPriceMessage.Size = new System.Drawing.Size(134, 18);
            this.warningPriceMessage.TabIndex = 6;
            this.warningPriceMessage.Text = "！只能是为数字";
            this.warningPriceMessage.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "价格：";
            // 
            // MenuAddBu
            // 
            this.MenuAddBu.Location = new System.Drawing.Point(82, 225);
            this.MenuAddBu.Margin = new System.Windows.Forms.Padding(4);
            this.MenuAddBu.Name = "MenuAddBu";
            this.MenuAddBu.Size = new System.Drawing.Size(112, 34);
            this.MenuAddBu.TabIndex = 4;
            this.MenuAddBu.Text = "添加";
            this.MenuAddBu.UseVisualStyleBackColor = true;
            this.MenuAddBu.Click += new System.EventHandler(this.MenuAddBu_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(1431, 102);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 40);
            this.label6.TabIndex = 5;
            this.label6.Text = "菜单添加";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(448, 78);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(297, 40);
            this.label7.TabIndex = 6;
            this.label7.Text = "菜单查看和修改";
            // 
            // MenuModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuModify";
            this.Text = "MenuModify";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.TextBox menuNameAddTB;
        private System.Windows.Forms.TextBox menuPriceAddTB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label warningNameMessage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label warningPriceMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button MenuAddBu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}