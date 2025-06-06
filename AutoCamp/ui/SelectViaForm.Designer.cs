namespace AutoCamp.ui
{
    partial class SelectViaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectViaForm));
            label1 = new Label();
            txtPathRoot = new TextBox();
            btnLoadProfile = new Button();
            label2 = new Label();
            cbbProfile = new ComboBox();
            btnLoadVia = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 19);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Path Root";
            // 
            // txtPathRoot
            // 
            txtPathRoot.Location = new Point(88, 16);
            txtPathRoot.Name = "txtPathRoot";
            txtPathRoot.Size = new Size(322, 23);
            txtPathRoot.TabIndex = 1;
            // 
            // btnLoadProfile
            // 
            btnLoadProfile.Location = new Point(416, 16);
            btnLoadProfile.Name = "btnLoadProfile";
            btnLoadProfile.Size = new Size(95, 25);
            btnLoadProfile.TabIndex = 2;
            btnLoadProfile.Text = "Load Profile";
            btnLoadProfile.UseVisualStyleBackColor = true;
            btnLoadProfile.Click += btnLoadProfile_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 60);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 3;
            label2.Text = "Profile";
            // 
            // cbbProfile
            // 
            cbbProfile.FormattingEnabled = true;
            cbbProfile.Location = new Point(88, 57);
            cbbProfile.Name = "cbbProfile";
            cbbProfile.Size = new Size(157, 23);
            cbbProfile.TabIndex = 4;
            // 
            // btnLoadVia
            // 
            btnLoadVia.Location = new Point(251, 57);
            btnLoadVia.Name = "btnLoadVia";
            btnLoadVia.Size = new Size(95, 23);
            btnLoadVia.TabIndex = 5;
            btnLoadVia.Text = "Load Via";
            btnLoadVia.UseVisualStyleBackColor = true;
            btnLoadVia.Click += btnLoadVia_Click;
            // 
            // SelectViaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(517, 103);
            Controls.Add(btnLoadVia);
            Controls.Add(cbbProfile);
            Controls.Add(label2);
            Controls.Add(btnLoadProfile);
            Controls.Add(txtPathRoot);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "SelectViaForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SelectViaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPathRoot;
        private Button btnLoadProfile;
        private Label label2;
        private ComboBox cbbProfile;
        private Button btnLoadVia;
    }
}