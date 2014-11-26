namespace iBams
{
    partial class ResetPassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.session1 = new DevExpress.Xpo.Session();
            this.UserNameTxtBox = new DevExpress.XtraEditors.TextEdit();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtScrtAns = new DevExpress.XtraEditors.TextEdit();
            this.subButton = new DevExpress.XtraEditors.SimpleButton();
            this.LoginPage = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.session1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNameTxtBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScrtAns.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(84, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login ID:";
            // 
            // session1
            // 
            this.session1.IsObjectModifiedOnNonPersistentPropertyChange = null;
            this.session1.TrackPropertiesModifications = false;
            // 
            // UserNameTxtBox
            // 
            this.UserNameTxtBox.Location = new System.Drawing.Point(136, 65);
            this.UserNameTxtBox.Name = "UserNameTxtBox";
            this.UserNameTxtBox.Size = new System.Drawing.Size(231, 20);
            this.UserNameTxtBox.TabIndex = 4;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(271, 90);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(96, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset Password";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(94, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "labelControl1";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(55, 72);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Secret Answer:";
            // 
            // txtScrtAns
            // 
            this.txtScrtAns.Location = new System.Drawing.Point(136, 65);
            this.txtScrtAns.Name = "txtScrtAns";
            this.txtScrtAns.Size = new System.Drawing.Size(231, 20);
            this.txtScrtAns.TabIndex = 8;
            // 
            // subButton
            // 
            this.subButton.Location = new System.Drawing.Point(271, 90);
            this.subButton.Name = "subButton";
            this.subButton.Size = new System.Drawing.Size(97, 23);
            this.subButton.TabIndex = 9;
            this.subButton.Text = "Submit";
            this.subButton.Click += new System.EventHandler(this.subButton_Click);
            // 
            // LoginPage
            // 
            this.LoginPage.Location = new System.Drawing.Point(185, 90);
            this.LoginPage.Name = "LoginPage";
            this.LoginPage.Size = new System.Drawing.Size(83, 23);
            this.LoginPage.TabIndex = 10;
            this.LoginPage.Text = "Cancle";
            this.LoginPage.Click += new System.EventHandler(this.LoginPage_Click);
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 160);
            this.Controls.Add(this.LoginPage);
            this.Controls.Add(this.subButton);
            this.Controls.Add(this.txtScrtAns);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.UserNameTxtBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset Password";
            ((System.ComponentModel.ISupportInitialize)(this.session1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNameTxtBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScrtAns.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.Xpo.Session session1;
        private DevExpress.XtraEditors.TextEdit UserNameTxtBox;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtScrtAns;
        private DevExpress.XtraEditors.SimpleButton subButton;
        private DevExpress.XtraEditors.SimpleButton LoginPage;

    }
}

