namespace iBams
{
    partial class BrowseDocument
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowseDocument));
            this.benefitDocumentCollection = new DevExpress.Xpo.XPCollection(this.components);
            this.session1 = new DevExpress.Xpo.Session(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.statusComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.findSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.searchForTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.benefitTypeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.benefitTypeCollection = new DevExpress.Xpo.XPCollection(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.bookAppointmentSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.sendToHOSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.printSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.reprocessSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.deleteSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.changeSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.insertSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGUID_Request4BenefitMaster = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID_Request4BenefitMaster = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.benefitDocumentCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.session1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchForTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.benefitTypeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.benefitTypeCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // benefitDocumentCollection
            // 
            this.benefitDocumentCollection.ObjectType = typeof(PBMSModel.PBMS.Request4BenefitMaster_New);
            this.benefitDocumentCollection.Session = this.session1;
            // 
            // session1
            // 
            this.session1.IsObjectModifiedOnNonPersistentPropertyChange = null;
            this.session1.TrackPropertiesModifications = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.statusComboBoxEdit);
            this.panelControl1.Controls.Add(this.findSimpleButton);
            this.panelControl1.Controls.Add(this.searchForTextEdit);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.benefitTypeLookUpEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(833, 65);
            this.panelControl1.TabIndex = 1;
            // 
            // statusComboBoxEdit
            // 
            this.statusComboBoxEdit.EditValue = "All";
            this.statusComboBoxEdit.Location = new System.Drawing.Point(91, 41);
            this.statusComboBoxEdit.Name = "statusComboBoxEdit";
            this.statusComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.statusComboBoxEdit.Properties.Items.AddRange(new object[] {
            "Unprocessed",
            "Processed",
            "All"});
            this.statusComboBoxEdit.Size = new System.Drawing.Size(222, 20);
            this.statusComboBoxEdit.TabIndex = 6;
            // 
            // findSimpleButton
            // 
            this.findSimpleButton.Image = ((System.Drawing.Image)(resources.GetObject("findSimpleButton.Image")));
            this.findSimpleButton.Location = new System.Drawing.Point(732, 38);
            this.findSimpleButton.Name = "findSimpleButton";
            this.findSimpleButton.Size = new System.Drawing.Size(75, 23);
            this.findSimpleButton.TabIndex = 3;
            this.findSimpleButton.Text = "&Find";
            this.findSimpleButton.Click += new System.EventHandler(this.findSimpleButton_Click);
            // 
            // searchForTextEdit
            // 
            this.searchForTextEdit.Location = new System.Drawing.Point(412, 41);
            this.searchForTextEdit.Name = "searchForTextEdit";
            this.searchForTextEdit.Size = new System.Drawing.Size(314, 20);
            this.searchForTextEdit.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Benefit Type:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(352, 41);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Search for:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(50, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Status:";
            // 
            // benefitTypeLookUpEdit
            // 
            this.benefitTypeLookUpEdit.Location = new System.Drawing.Point(91, 15);
            this.benefitTypeLookUpEdit.Name = "benefitTypeLookUpEdit";
            this.benefitTypeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.benefitTypeLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BenefitTypeName", "Benefit Type", 101, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.benefitTypeLookUpEdit.Properties.DataSource = this.benefitTypeCollection;
            this.benefitTypeLookUpEdit.Properties.DisplayMember = "BenefitTypeName";
            this.benefitTypeLookUpEdit.Properties.DropDownRows = 10;
            this.benefitTypeLookUpEdit.Properties.NullText = "[Record is empty]";
            this.benefitTypeLookUpEdit.Properties.NullValuePrompt = "[Select a benefit type]";
            this.benefitTypeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = true;
            this.benefitTypeLookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.benefitTypeLookUpEdit.Properties.ValueMember = "ID_BenefitType";
            this.benefitTypeLookUpEdit.Size = new System.Drawing.Size(222, 20);
            this.benefitTypeLookUpEdit.TabIndex = 4;
            // 
            // benefitTypeCollection
            // 
            this.benefitTypeCollection.ObjectType = typeof(PBMSModel.PBMS.BenefitType);
            this.benefitTypeCollection.Session = this.session1;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.bookAppointmentSimpleButton);
            this.panelControl2.Controls.Add(this.sendToHOSimpleButton);
            this.panelControl2.Controls.Add(this.printSimpleButton);
            this.panelControl2.Controls.Add(this.reprocessSimpleButton);
            this.panelControl2.Controls.Add(this.deleteSimpleButton);
            this.panelControl2.Controls.Add(this.changeSimpleButton);
            this.panelControl2.Controls.Add(this.insertSimpleButton);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 465);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(833, 44);
            this.panelControl2.TabIndex = 2;
            // 
            // bookAppointmentSimpleButton
            // 
            this.bookAppointmentSimpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bookAppointmentSimpleButton.Image = ((System.Drawing.Image)(resources.GetObject("bookAppointmentSimpleButton.Image")));
            this.bookAppointmentSimpleButton.Location = new System.Drawing.Point(686, 4);
            this.bookAppointmentSimpleButton.Name = "bookAppointmentSimpleButton";
            this.bookAppointmentSimpleButton.Size = new System.Drawing.Size(142, 35);
            this.bookAppointmentSimpleButton.TabIndex = 0;
            this.bookAppointmentSimpleButton.Text = "&Book Appointment";
            this.bookAppointmentSimpleButton.Click += new System.EventHandler(this.bookAppointmentSimpleButton_Click);
            // 
            // sendToHOSimpleButton
            // 
            this.sendToHOSimpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendToHOSimpleButton.Image = ((System.Drawing.Image)(resources.GetObject("sendToHOSimpleButton.Image")));
            this.sendToHOSimpleButton.Location = new System.Drawing.Point(573, 4);
            this.sendToHOSimpleButton.Name = "sendToHOSimpleButton";
            this.sendToHOSimpleButton.Size = new System.Drawing.Size(107, 35);
            this.sendToHOSimpleButton.TabIndex = 0;
            this.sendToHOSimpleButton.Text = "Se&nd to HO";
            this.sendToHOSimpleButton.Click += new System.EventHandler(this.sendToHOSimpleButton_Click);
            // 
            // printSimpleButton
            // 
            this.printSimpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.printSimpleButton.Image = ((System.Drawing.Image)(resources.GetObject("printSimpleButton.Image")));
            this.printSimpleButton.Location = new System.Drawing.Point(472, 4);
            this.printSimpleButton.Name = "printSimpleButton";
            this.printSimpleButton.Size = new System.Drawing.Size(95, 35);
            this.printSimpleButton.TabIndex = 0;
            this.printSimpleButton.Text = "&Print";
            this.printSimpleButton.Click += new System.EventHandler(this.printSimpleButton_Click);
            // 
            // reprocessSimpleButton
            // 
            this.reprocessSimpleButton.Image = ((System.Drawing.Image)(resources.GetObject("reprocessSimpleButton.Image")));
            this.reprocessSimpleButton.Location = new System.Drawing.Point(309, 4);
            this.reprocessSimpleButton.Name = "reprocessSimpleButton";
            this.reprocessSimpleButton.Size = new System.Drawing.Size(95, 35);
            this.reprocessSimpleButton.TabIndex = 0;
            this.reprocessSimpleButton.Text = "&Reprocess";
            // 
            // deleteSimpleButton
            // 
            this.deleteSimpleButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteSimpleButton.Image")));
            this.deleteSimpleButton.Location = new System.Drawing.Point(208, 4);
            this.deleteSimpleButton.Name = "deleteSimpleButton";
            this.deleteSimpleButton.Size = new System.Drawing.Size(95, 35);
            this.deleteSimpleButton.TabIndex = 0;
            this.deleteSimpleButton.Text = "&Delete";
            this.deleteSimpleButton.Click += new System.EventHandler(this.deleteSimpleButton_Click);
            // 
            // changeSimpleButton
            // 
            this.changeSimpleButton.Image = ((System.Drawing.Image)(resources.GetObject("changeSimpleButton.Image")));
            this.changeSimpleButton.Location = new System.Drawing.Point(107, 4);
            this.changeSimpleButton.Name = "changeSimpleButton";
            this.changeSimpleButton.Size = new System.Drawing.Size(95, 35);
            this.changeSimpleButton.TabIndex = 0;
            this.changeSimpleButton.Text = "&Change";
            this.changeSimpleButton.Click += new System.EventHandler(this.changeSimpleButton_Click);
            // 
            // insertSimpleButton
            // 
            this.insertSimpleButton.Image = ((System.Drawing.Image)(resources.GetObject("insertSimpleButton.Image")));
            this.insertSimpleButton.Location = new System.Drawing.Point(5, 4);
            this.insertSimpleButton.Name = "insertSimpleButton";
            this.insertSimpleButton.Size = new System.Drawing.Size(95, 35);
            this.insertSimpleButton.TabIndex = 0;
            this.insertSimpleButton.Text = "&Inset";
            this.insertSimpleButton.Click += new System.EventHandler(this.insertSimpleButton_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.benefitDocumentCollection;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 65);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(833, 400);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGUID_Request4BenefitMaster,
            this.colPIN,
            this.colName,
            this.colCreatedDate,
            this.colID_Request4BenefitMaster});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // colGUID_Request4BenefitMaster
            // 
            this.colGUID_Request4BenefitMaster.FieldName = "GUID_Request4BenefitMaster";
            this.colGUID_Request4BenefitMaster.Name = "colGUID_Request4BenefitMaster";
            this.colGUID_Request4BenefitMaster.Width = 20;
            // 
            // colPIN
            // 
            this.colPIN.FieldName = "PIN";
            this.colPIN.Name = "colPIN";
            this.colPIN.OptionsColumn.AllowEdit = false;
            this.colPIN.Visible = true;
            this.colPIN.VisibleIndex = 2;
            this.colPIN.Width = 183;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 370;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.OptionsColumn.AllowEdit = false;
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 3;
            this.colCreatedDate.Width = 187;
            // 
            // colID_Request4BenefitMaster
            // 
            this.colID_Request4BenefitMaster.Caption = "gridColumn1";
            this.colID_Request4BenefitMaster.FieldName = "ID_Request4BenefitMaster";
            this.colID_Request4BenefitMaster.Name = "colID_Request4BenefitMaster";
            // 
            // BrowseDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 509);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "BrowseDocument";
            this.Text = "Browse Documents";
            this.Load += new System.EventHandler(this.BrowseDocument_Load);
            ((System.ComponentModel.ISupportInitialize)(this.benefitDocumentCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.session1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchForTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.benefitTypeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.benefitTypeCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton bookAppointmentSimpleButton;
        private DevExpress.XtraEditors.SimpleButton sendToHOSimpleButton;
        private DevExpress.XtraEditors.SimpleButton printSimpleButton;
        private DevExpress.XtraEditors.SimpleButton reprocessSimpleButton;
        private DevExpress.XtraEditors.SimpleButton deleteSimpleButton;
        private DevExpress.XtraEditors.SimpleButton changeSimpleButton;
        private DevExpress.XtraEditors.SimpleButton insertSimpleButton;
        private DevExpress.XtraEditors.SimpleButton findSimpleButton;
        private DevExpress.XtraEditors.TextEdit searchForTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.Xpo.XPCollection benefitDocumentCollection;
        private DevExpress.Xpo.Session session1;
        private DevExpress.Xpo.XPCollection benefitTypeCollection;
        private DevExpress.XtraEditors.LookUpEdit benefitTypeLookUpEdit;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colGUID_Request4BenefitMaster;
        private DevExpress.XtraGrid.Columns.GridColumn colPIN;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraEditors.ComboBoxEdit statusComboBoxEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colID_Request4BenefitMaster;
    }
}