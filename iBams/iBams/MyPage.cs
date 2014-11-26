using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PBMSModel;
using PBMSModel.PBMS;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.XtraData;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using Dynamsoft.DotNet.TWAIN.Enums;


namespace iBams
{
    public partial class MyPage : DevExpress.XtraEditors.XtraForm
    {
        public Guid ID { get; set; }
        public string PIN { get; set; }
        public string FormMode { get; set; }

        string filename = "";
        string Imagepath = "";
        string DocumentPath = "";
        public MyPage()
        {
            InitializeComponent();
            this.session1.ConnectionString = PBMSModel.PBMS.ConnectionHelper.ConnectionString;
            dynamicDotNetTwain1.SupportedDeviceType = EnumSupportedDeviceType.SDT_WEBCAM;

            dynamicDotNetTwain2.SupportedDeviceType = Dynamsoft.DotNet.TWAIN.Enums.EnumSupportedDeviceType.SDT_ALL; // enable capturing images from both scanners and webcams
            int lngNum;
            dynamicDotNetTwain2.OpenSourceManager();
            for (lngNum = 0; lngNum < dynamicDotNetTwain2.SourceCount; lngNum++)
            {
                cmbSource.Properties.Items.Add(dynamicDotNetTwain2.SourceNameItems(Convert.ToInt16(lngNum))); // display the available imaging devices
            }
            if (lngNum > 0)
                cmbSource.SelectedIndex = 0;  
        }

        private void MyPage_Load(object sender, EventArgs e)
        {
            try
            {
                //m_iDesignWidth = this.Width;
                //this.chkContainer.CheckedChanged += new System.EventHandler(this.chkContainer_CheckedChanged);
                //this.chkContainer.Checked = false;

                for (short i = 0; i < dynamicDotNetTwain1.SourceCount; i++)
                {
                    string strSourceName = dynamicDotNetTwain1.SourceNameItems(i);
                    if (strSourceName != null)
                        cbxSources.Properties.Items.Add(strSourceName);
                }

                //if (cbxSources.Properties.Items.Count > 0)
                //    cbxSources.SelectedIndex = 0;

                //btnTakePics.Location = new Point(50, 182);
                //btnTakePics.Width = 91;
                if (!string.IsNullOrWhiteSpace(this.PIN))
                {
                    this.txtSearchPIN.Text = this.PIN;
                    this.btnFind_Click(null, null);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            //if (ID!=null)
            //{

            //}
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
//            using (var session1 = session1)
  //          {
                try
                {
                   // Guid ID= Guid.Parse(txtGUID_request4BenMaster.Text);
                    var requestTable = new XPQuery<Request4BenefitMaster_New>(session1).Where(item => item.PIN ==txtPIN.Text.Trim()).FirstOrDefault();
                        requestTable.Name=txtName.Text;
                        requestTable.DateOfDeath=DateTime.Parse(txtDateOfBirth.Text);
                        requestTable.AccountNumber = int.Parse(txtAccountNumber.Text);
                        requestTable.LumpSumWithdrawal=Decimal.Parse(txtMaxLumpWithrawable.Text);
                        requestTable.MonthlyProgWithdrawal=Decimal.Parse(txtMonthlyProgWithdrawal.Text);
                        requestTable.NoOfAreas=int.Parse(txtNoOfArrears.Text) ;
                        requestTable.ProgWithdrawalArrears=Decimal.Parse(txtProgWithdrawalArreas.Text) ;
                        requestTable.TotalBenefitPayable=Decimal.Parse(txtTotalBenefitPayable.Text);
                        requestTable.RoutingNumber =int.Parse( txtRoutingNumber.Text);
                        requestTable.DedicatedBank = txtBankName.Text;
                        requestTable.PENCOMRefNo=txtPencomReference.Text;
                        requestTable.LastEmployerName= txtNameOfOrganisation.Text;
                        requestTable.DateOfDeath=DateTime.Parse(txtDateOfExit.Text);
                        requestTable.Comments= txtNaration.Text;
                        session1.Save(requestTable);

                        string filename = txtPIN.Text.ToString();
                        string Imagepath = @"C:\node\" + filename + ".jpg";
                        
                        bool result = dynamicDotNetTwain1.SaveAsJPEG(Imagepath, dynamicDotNetTwain1.CurrentImageIndexInBuffer);

                        if (MessageBox.Show(Owner, "Saved Successfully", "Request for Benefit Master") == System.Windows.Forms.DialogResult.OK)
                        {
                            this.Close();
                        }
                }
                catch { MessageBox.Show(Owner, "Error Occured", "Request for Benefit Master"); }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            using (var session1 = new Session())
            {
                session1.ConnectionString = PBMSModel.PBMS.ConnectionHelper.ConnectionString;
                try
                {
                    splashScreenManager1.ShowWaitForm();
                    filename = txtSearchPIN.Text.ToString();
                    Imagepath = @"C:\node\" + filename + ".jpg";

                    var query = new XPQuery<Request4BenefitMaster_New>(session1).Where(item => item.PIN == txtSearchPIN.Text.Trim()).FirstOrDefault();

                    if (query != null)
                    {
                        txtName.Text = query.Name;
                        txtDateOfBirth.Text = query.BirthDate.ToShortDateString();
                        txtAccountNumber.Text = query.AccountNumber.ToString();
                        txtMaxLumpWithrawable.Text = query.LumpSumWithdrawal.ToString();
                        txtMonthlyProgWithdrawal.Text = query.MonthlyProgWithdrawal.ToString();
                        txtNoOfArrears.Text = query.NoOfAreas.ToString();
                        txtProgWithdrawalArreas.Text = query.ProgWithdrawalArrears.ToString();
                        txtTotalBenefitPayable.Text = query.TotalBenefitPayable.ToString();
                        txtRoutingNumber.Text = query.RoutingNumber.ToString();
                        txtBankName.Text = query.DedicatedBank;
                        txtPIN.Text = query.PIN;
                        txtPencomReference.Text = query.PENCOMRefNo;
                        txtNameOfOrganisation.Text = query.LastEmployerName;
                        txtDateOfExit.Text = query.DateOfDeath.ToShortDateString();
                        txtNaration.Text = query.Comments;
                        txtGUID_request4BenMaster.Text = query.GUID_Request4BenefitMaster.ToString();
                    }

                    bool imageResult = dynamicDotNetTwain1.LoadImage(Imagepath);
                    if  (imageResult)
                    {
                        dynamicDotNetTwain1.Visible = true;
                        picRetiree.Visible = false;
                        btnTakePics.Text = "Change Pics";
                    }

                    ///filter the grid
                    gridView1.ActiveFilterString = "Retirement=true";
                }
                catch { MessageBox.Show(Owner, "PIN does not exist", "Request for Benefit Master"); }
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void btnTakePics_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxSources.Properties.Items.Count > 0)
                {
                    //if (cbxSources.Properties.Items.Count > 0)
                        cbxSources.SelectedIndex = 0;
                    dynamicDotNetTwain1.IfShowUI = true;
                    dynamicDotNetTwain1.SetVideoContainer(this.picRetiree);
                    dynamicDotNetTwain1.EnableSource();
                    btnTakePics.Visible = false;
                    bttnSnap.Visible = true;
                    bttnCancelShot.Visible = true;
                    bttnSnap.Location = new Point(479, 217);
                    bttnCancelShot.Location = new Point(559, 217);
                    picRetiree.Visible = true;
                    //shows only the current image
                    dynamicDotNetTwain1.SetViewMode(-1, -1);
                    // enable zooming image using hot key.
                    dynamicDotNetTwain1.EnableInteractiveZoom = true;
                    dynamicDotNetTwain1.IfShowUI = false;
                    dynamicDotNetTwain1.RemoveAllImages();

                }
                else
                {
                    MessageBox.Show("No webcam source detected!");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void bttnSnap_Click(object sender, EventArgs e)
        {
            try
            {
                if (bttnSnap.Text == "Re-Snap")
                {
                    picRetiree.Visible = true;
                    dynamicDotNetTwain1.RemoveAllImages();
                    bttnSnap.Text = "Snap";
                }
                else
                {
                    dynamicDotNetTwain1.IfShowUI = true;
                    dynamicDotNetTwain1.SetVideoContainer(this.picRetiree);
                    dynamicDotNetTwain1.EnableSource();

                    //Arrangement and visibilty of controls
                    btnTakePics.Visible = false;
                    bttnSnap.Visible = true;
                    bttnCancelShot.Visible = true;
                    bttnSnap.Location = new Point(479, 217);
                    bttnCancelShot.Location = new Point(559, 217);
                    picRetiree.Visible = false;
                    dynamicDotNetTwain1.Visible = true;
                    dynamicDotNetTwain1.Width = 185;
                    dynamicDotNetTwain1.Height = 168;
                    bttnSnap.Text = "Re-Snap";

                }
            }
            catch { }
        }

        private void bttnCancelShot_Click(object sender, EventArgs e)
        {
            try
            {
                picRetiree.Visible = false;
                dynamicDotNetTwain1.RemoveAllImages();
                btnTakePics.Visible = true;
                bttnSnap.Visible = false;
                bttnCancelShot.Visible = false;
                bttnSnap.Text = "Snap";
                dynamicDotNetTwain1.DisableSource();
                dynamicDotNetTwain1.CloseSource();

                if (btnTakePics.Text == "Change Pics")
                {
                    bool imageResult = dynamicDotNetTwain1.LoadImage(Imagepath);
                    if (imageResult)
                    {
                        dynamicDotNetTwain1.Visible = true;
                        picRetiree.Visible = false;
                    }
                }
            }
            catch (Exception err) {}
            
        }

        private void cbxSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBoxEdit)sender).SelectedIndex >= 0 && ((ComboBoxEdit)sender).SelectedIndex < dynamicDotNetTwain1.SourceCount)
            {
                dynamicDotNetTwain1.SelectSourceByIndex(cbxSources.SelectedIndex);
                dynamicDotNetTwain1.OpenSource();
            }
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnScanDocs_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
                for (int i = 0; i < gridView1.SelectedRowsCount; ++i)
                {
                    try
                    {
                        if (txtPIN.Text != string.Empty)
                        {
                            var ID = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "ID_DocumentMaster");
                            var Name = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "DocumentMaster");

                            //this is the name the scaned document should be named
                            string DocumentName = txtPIN.Text + ID;
                            dynamicDotNetTwain2.IfAppendImage = true;
                            AcquireImage(); // a
                            DocumentPath = @"C:\node\" + DocumentName + ".jpg";
                            bool result = dynamicDotNetTwain2.SaveAsJPEG(DocumentPath, dynamicDotNetTwain2.CurrentImageIndexInBuffer);

                            MessageBox.Show(Owner, "Document: " + Name + " scaned Successfully", "Request for Benefit Master");
                        }

                    }
                    catch { MessageBox.Show(Owner, "Error Scanning Document", "Request for Benefit Master"); }

                }
            
        }

        private void AcquireImage()
        {
            //if (cbxSources.Properties.Items.Count > 0)
            //    cbxSources.SelectedIndex = 0;
            dynamicDotNetTwain2.SelectSourceByIndex(Convert.ToInt16(cmbSource.SelectedIndex));
            dynamicDotNetTwain2.IfShowUI = chkIfShowUI.Checked;
            dynamicDotNetTwain2.OpenSource();
            dynamicDotNetTwain2.IfDisableSourceAfterAcquire = true;

            dynamicDotNetTwain2.IfShowUI = chkIfShowUI.Checked;

            try { dynamicDotNetTwain2.AcquireImage(); }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }


    }
}
