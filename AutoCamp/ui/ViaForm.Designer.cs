namespace AutoCamp.ui
{
    partial class ViaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViaForm));
            panel1 = new Panel();
            cbxProxy = new CheckBox();
            btnLoadDataVia = new Button();
            button2 = new Button();
            txtProxy = new TextBox();
            txtPasswordVia = new TextBox();
            txtViaData = new TextBox();
            txtCookie = new TextBox();
            txtPathFileRoot = new TextBox();
            lbUidVia = new Label();
            label6 = new Label();
            lb2Fa = new Label();
            label5 = new Label();
            label7 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            cbxTypeLogin = new ComboBox();
            btnLoginVia = new Button();
            btnSaveData = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(cbxProxy);
            panel1.Controls.Add(btnLoadDataVia);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(txtProxy);
            panel1.Controls.Add(txtPasswordVia);
            panel1.Controls.Add(txtViaData);
            panel1.Controls.Add(txtCookie);
            panel1.Controls.Add(txtPathFileRoot);
            panel1.Controls.Add(lbUidVia);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(lb2Fa);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(690, 277);
            panel1.TabIndex = 0;
            // 
            // cbxProxy
            // 
            cbxProxy.AutoSize = true;
            cbxProxy.Location = new Point(92, 232);
            cbxProxy.Name = "cbxProxy";
            cbxProxy.Size = new Size(56, 19);
            cbxProxy.TabIndex = 3;
            cbxProxy.Text = "Proxy";
            cbxProxy.UseVisualStyleBackColor = true;
            // 
            // btnLoadDataVia
            // 
            btnLoadDataVia.Location = new Point(610, 46);
            btnLoadDataVia.Name = "btnLoadDataVia";
            btnLoadDataVia.Size = new Size(75, 23);
            btnLoadDataVia.TabIndex = 2;
            btnLoadDataVia.Text = "Load";
            btnLoadDataVia.UseVisualStyleBackColor = true;
            btnLoadDataVia.Click += btnLoadDataVia_Click;
            // 
            // button2
            // 
            button2.Location = new Point(610, 6);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Chọn";
            button2.UseVisualStyleBackColor = true;
            // 
            // txtProxy
            // 
            txtProxy.Location = new Point(154, 230);
            txtProxy.Name = "txtProxy";
            txtProxy.Size = new Size(450, 23);
            txtProxy.TabIndex = 1;
            // 
            // txtPasswordVia
            // 
            txtPasswordVia.Location = new Point(92, 113);
            txtPasswordVia.Name = "txtPasswordVia";
            txtPasswordVia.Size = new Size(207, 23);
            txtPasswordVia.TabIndex = 1;
            // 
            // txtViaData
            // 
            txtViaData.Location = new Point(92, 46);
            txtViaData.Name = "txtViaData";
            txtViaData.Size = new Size(512, 23);
            txtViaData.TabIndex = 1;
            // 
            // txtCookie
            // 
            txtCookie.Location = new Point(90, 188);
            txtCookie.Name = "txtCookie";
            txtCookie.Size = new Size(514, 23);
            txtCookie.TabIndex = 1;
            // 
            // txtPathFileRoot
            // 
            txtPathFileRoot.AcceptsReturn = true;
            txtPathFileRoot.Location = new Point(92, 6);
            txtPathFileRoot.Name = "txtPathFileRoot";
            txtPathFileRoot.Size = new Size(512, 23);
            txtPathFileRoot.TabIndex = 1;
            // 
            // lbUidVia
            // 
            lbUidVia.AutoSize = true;
            lbUidVia.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbUidVia.ForeColor = Color.Green;
            lbUidVia.Location = new Point(92, 84);
            lbUidVia.Name = "lbUidVia";
            lbUidVia.Size = new Size(87, 15);
            lbUidVia.TabIndex = 0;
            lbUidVia.Text = "XXXXXXXXXX";
            lbUidVia.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 116);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 0;
            label6.Text = "Password";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // lb2Fa
            // 
            lb2Fa.AutoSize = true;
            lb2Fa.Location = new Point(92, 152);
            lb2Fa.Name = "lb2Fa";
            lb2Fa.Size = new Size(77, 15);
            lb2Fa.TabIndex = 0;
            lb2Fa.Text = "XXXXXXXXXX";
            lb2Fa.TextAlign = ContentAlignment.TopCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 191);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 0;
            label5.Text = "Cookie";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 152);
            label7.Name = "label7";
            label7.Size = new Size(26, 15);
            label7.TabIndex = 0;
            label7.Text = "2FA";
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 84);
            label4.Name = "label4";
            label4.Size = new Size(26, 15);
            label4.TabIndex = 0;
            label4.Text = "UID";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 49);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 0;
            label3.Text = "VIA Data";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 9);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 0;
            label1.Text = "Root";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // cbxTypeLogin
            // 
            cbxTypeLogin.FormattingEnabled = true;
            cbxTypeLogin.Items.AddRange(new object[] { "uid|pass", "cookie" });
            cbxTypeLogin.Location = new Point(12, 306);
            cbxTypeLogin.Name = "cbxTypeLogin";
            cbxTypeLogin.Size = new Size(85, 23);
            cbxTypeLogin.TabIndex = 4;
            cbxTypeLogin.Text = "Type login";
            // 
            // btnLoginVia
            // 
            btnLoginVia.Location = new Point(103, 306);
            btnLoginVia.Name = "btnLoginVia";
            btnLoginVia.Size = new Size(75, 23);
            btnLoginVia.TabIndex = 2;
            btnLoginVia.Text = "Login";
            btnLoginVia.UseVisualStyleBackColor = true;
            btnLoginVia.Click += btnLoginVia_Click;
            // 
            // btnSaveData
            // 
            btnSaveData.Location = new Point(623, 300);
            btnSaveData.Name = "btnSaveData";
            btnSaveData.Size = new Size(79, 33);
            btnSaveData.TabIndex = 1;
            btnSaveData.Text = "Lưu data";
            btnSaveData.UseVisualStyleBackColor = true;
            btnSaveData.Click += btnSaveData_Click;
            // 
            // ViaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(714, 344);
            Controls.Add(btnSaveData);
            Controls.Add(cbxTypeLogin);
            Controls.Add(panel1);
            Controls.Add(btnLoginVia);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ViaForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ViaForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnSaveData;
        private Label label1;
        private Button button2;
        private TextBox txtPathFileRoot;
        private TextBox txtViaData;
        private Label label3;
        private Label lbUidVia;
        private Label label4;
        private TextBox txtPasswordVia;
        private Label label6;
        private Label lb2Fa;
        private Label label7;
        private ComboBox cbxTypeLogin;
        private CheckBox cbxProxy;
        private TextBox txtProxy;
        private Button btnLoginVia;
        private Button btnLoadDataVia;
        private TextBox txtCookie;
        private Label label5;
    }
}