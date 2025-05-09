namespace SpielParadies
{
    partial class EingabeName
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
            label1 = new Label();
            txtName = new TextBox();
            btnOk = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(257, 143);
            label1.Name = "label1";
            label1.Size = new Size(234, 64);
            label1.TabIndex = 0;
            label1.Text = "     Hallo Gamer\r\nGib dein Namen ein:";
            // 
            // txtName
            // 
            txtName.Location = new Point(269, 237);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 39);
            txtName.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(475, 233);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(84, 46);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // EingabeName
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOk);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "EingabeName";
            Text = "EingabeName";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private Button btnOk;
    }
}