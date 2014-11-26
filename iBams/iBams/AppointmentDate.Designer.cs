namespace iBams
{
    partial class AppointmentDate
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.selectSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.selectSimpleButton);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 142);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(224, 29);
            this.panelControl1.TabIndex = 1;
            // 
            // selectSimpleButton
            // 
            this.selectSimpleButton.Location = new System.Drawing.Point(144, 3);
            this.selectSimpleButton.Name = "selectSimpleButton";
            this.selectSimpleButton.Size = new System.Drawing.Size(75, 23);
            this.selectSimpleButton.TabIndex = 0;
            this.selectSimpleButton.Text = "&Select";
            this.selectSimpleButton.Click += new System.EventHandler(this.selectSimpleButton_Click);
            this.selectSimpleButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AppointmentDate_KeyPress);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthCalendar1.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AppointmentDate_KeyPress);
            // 
            // AppointmentDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 171);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.monthCalendar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AppointmentDate";
            this.Text = "Select Appointment Date";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AppointmentDate_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton selectSimpleButton;
        public System.Windows.Forms.MonthCalendar monthCalendar1;



    }
}