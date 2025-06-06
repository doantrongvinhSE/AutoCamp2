namespace AutoCamp.ui
{
    partial class AddCreditOptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCreditOptionsForm));
            panel1 = new Panel();
            label4 = new Label();
            cbbTimezone = new ComboBox();
            label3 = new Label();
            cbbCurrency = new ComboBox();
            cbbCountry = new ComboBox();
            label2 = new Label();
            cbChangeInfo = new CheckBox();
            btnSaveCreditData = new Button();
            label1 = new Label();
            txtCreditData = new RichTextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cbbTimezone);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cbbCurrency);
            panel1.Controls.Add(cbbCountry);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbChangeInfo);
            panel1.Controls.Add(btnSaveCreditData);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtCreditData);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(546, 405);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(317, 118);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 10;
            label4.Text = "Múi giờ";
            // 
            // cbbTimezone
            // 
            cbbTimezone.FormattingEnabled = true;
            cbbTimezone.Location = new Point(378, 115);
            cbbTimezone.Name = "cbbTimezone";
            cbbTimezone.Size = new Size(157, 23);
            cbbTimezone.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(317, 89);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 7;
            label3.Text = "Tiền Tệ";
            // 
            // cbbCurrency
            // 
            cbbCurrency.FormattingEnabled = true;
            cbbCurrency.Location = new Point(378, 86);
            cbbCurrency.Name = "cbbCurrency";
            cbbCurrency.Size = new Size(157, 23);
            cbbCurrency.TabIndex = 6;
            // 
            // cbbCountry
            // 
            cbbCountry.FormattingEnabled = true;
            cbbCountry.Location = new Point(378, 57);
            cbbCountry.Name = "cbbCountry";
            cbbCountry.Size = new Size(157, 23);
            cbbCountry.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(317, 60);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 5;
            label2.Text = "Quốc gia";
            // 
            // cbChangeInfo
            // 
            cbChangeInfo.AutoSize = true;
            cbChangeInfo.Location = new Point(317, 27);
            cbChangeInfo.Name = "cbChangeInfo";
            cbChangeInfo.Size = new Size(164, 19);
            cbChangeInfo.TabIndex = 4;
            cbChangeInfo.Text = "Change info trước khi add";
            cbChangeInfo.UseVisualStyleBackColor = true;
            // 
            // btnSaveCreditData
            // 
            btnSaveCreditData.Location = new Point(248, 365);
            btnSaveCreditData.Name = "btnSaveCreditData";
            btnSaveCreditData.Size = new Size(75, 28);
            btnSaveCreditData.TabIndex = 3;
            btnSaveCreditData.Text = "Lưu";
            btnSaveCreditData.UseVisualStyleBackColor = true;
            btnSaveCreditData.Click += btnSaveCreditData_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 9);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "Credit info";
            // 
            // txtCreditData
            // 
            txtCreditData.Location = new Point(8, 27);
            txtCreditData.Name = "txtCreditData";
            txtCreditData.Size = new Size(287, 331);
            txtCreditData.TabIndex = 1;
            txtCreditData.Text = "";
            // 
            // AddCreditOptionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(546, 405);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AddCreditOptionsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddCreditOptionsForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private RichTextBox txtCreditData;
        private Button btnSaveCreditData;
        private CheckBox cbChangeInfo;
        private Label label2;
        private ComboBox cbbCountry;
        private Label label3;
        private Label label4;
        private ComboBox cbbTimezone;
        private ComboBox cbbCurrency;
    }
}