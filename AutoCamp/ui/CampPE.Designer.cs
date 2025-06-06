namespace AutoCamp.ui
{
    partial class CampPE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CampPE));
            txtTarget = new RichTextBox();
            label1 = new Label();
            btnSave = new Button();
            SuspendLayout();
            // 
            // txtTarget
            // 
            txtTarget.Location = new Point(12, 27);
            txtTarget.Name = "txtTarget";
            txtTarget.Size = new Size(361, 144);
            txtTarget.TabIndex = 0;
            txtTarget.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 1;
            label1.Text = "Target Text";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(298, 177);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // CampPE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 211);
            Controls.Add(btnSave);
            Controls.Add(label1);
            Controls.Add(txtTarget);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CampPE";
            StartPosition = FormStartPosition.CenterParent;
            Text = "CampPE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox txtTarget;
        private Label label1;
        private Button btnSave;
    }
}