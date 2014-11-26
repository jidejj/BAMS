using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Data.Filtering;
using System.IO;
//using AppLimit.CloudComputing.SharpBox;
//using AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox;
using DevExpress.Xpo;
using PBMSModel.PBMS;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using System.Threading;

namespace iBams
{
    public partial class BrowseDocument : DevExpress.XtraEditors.XtraForm
    {
        public BrowseDocument()
        {
            InitializeComponent();
            this.session1.ConnectionString = PBMSModel.PBMS.ConnectionHelper.ConnectionString;
        }

        private void findSimpleButton_Click(object sender, EventArgs e)
        {
            string status = "";
            switch (this.statusComboBoxEdit.Text.Trim())
            {
                case "Unprocessed":
                    status = "0";
                    break;
                case "Processed":
                    status = "1";
                    break;
                case "All":
                    status = "All";
                    break;
            }
            string criteria = string.Format("(ID_BenefitType = '{0}') And (Status = '{1}') And (Name Like '%{2}%' Or PIN Like '%{2}%')",
                                            this.benefitTypeLookUpEdit.EditValue, status, this.searchForTextEdit.Text.Trim());
            if (status == "All")
                criteria = string.Format("(Name Like '%{0}%' Or PIN Like '%{0}%')", this.searchForTextEdit.Text.Trim());
            else
                criteria = string.Format("(Status = '{0}') And (Name Like '%{1}%' Or PIN Like '%{1}%')", status, this.searchForTextEdit.Text.Trim());
            
            CriteriaOperator filter = CriteriaOperator.Parse(criteria); //"ID_BenefitType='" + this.benefitTypeLookUpEdit.EditValue + "'"
            this.benefitDocumentCollection.Filter = filter;
            //if (this.benefitTypeLookUpEdit.EditValue != null)
            //{
            //    this.gridView1.ActiveFilterString = "ID_BenefitType='" + this.benefitTypeLookUpEdit.EditValue.ToString() + "'";
            //}
        }

        private void sendToHOSimpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.SelectedRowsCount > 0)
                {
                    // set the DropBox folder path
                    string dropBoxPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\DropBox";
                    string dropBoxFolder = dropBoxPath + "\\BenefitDocuments";

                    // confirm if dropbox has been installed on this machine againts the logged in user name
                    if (!Directory.Exists(dropBoxPath))
                    {
                        MessageBox.Show("Dropbox hasn't been installed on this machine. Install DropBox for Windows and try again.", "DropBox not installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // create the DropBox save folder if not exists
                    if (!Directory.Exists(dropBoxFolder))
                    {
                        Directory.CreateDirectory(dropBoxFolder);
                    }

                    //==================== move the selected person's files to the DropBox folder =====================
                    // obtain the source folder/file
                    string sourceFolder = Properties.Settings.Default.PBMSPath + "\\Pix", sourceFile = "";
                    if (!Directory.Exists(sourceFolder))
                        Directory.CreateDirectory(sourceFolder);

                    if (MessageBox.Show("Are you sure you want to send the selected people files to the Head Office?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int sentFilesCount = 0;
                        for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                        {
                            var GUID_Request4BenefitMaster = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "GUID_Request4BenefitMaster");
                            if (GUID_Request4BenefitMaster != null)
                            {
                                XPQuery<Request4BenefitMaster_New> rows = this.session1.Query<Request4BenefitMaster_New>();
                                Guid ID = (Guid)GUID_Request4BenefitMaster;
                                var row = rows.FirstOrDefault(b => b.GUID_Request4BenefitMaster == ID);

                                if (row != null)
                                {
                                    var documentsSubmitted = this.session1.Query<Request4BenefitDocs>().Where(item => item.GUID_Request4BenefitMaster.GUID_Request4BenefitMaster == ID).ToList();

                                    if (documentsSubmitted.Count > 0)
                                    {
                                        foreach (Request4BenefitDocs document in documentsSubmitted)
                                        {
                                            sourceFile = document.ScanFileName;
                                            File.Copy(sourceFolder + sourceFile, dropBoxFolder + "\\" + sourceFile, true);
                                            sentFilesCount++;
                                        }
                                    }
                                }
                            }
                        }

                        if (sentFilesCount > 0)
                            MessageBox.Show("The selected people files has been sent to the head office", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("No document has been submitted for the selected people.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bookAppointmentSimpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.SelectedRowsCount > 0)
                {
                    AppointmentDate appointmentDate = new AppointmentDate();
                    appointmentDate.ShowDialog();
                    if (appointmentDate.IsAppointmentDateSet)
                    {
                        DateTime nextAppointmentDate = appointmentDate.monthCalendar1.SelectionRange.Start;
                        int updateCount = 0;

                        session1.BeginTransaction();

                        try
                        {
                            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                            {
                                var GUID_Request4BenefitMaster = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "GUID_Request4BenefitMaster");
                                if (GUID_Request4BenefitMaster != null)
                                {
                                    XPQuery<Request4BenefitMaster_New> rows = this.session1.Query<Request4BenefitMaster_New>();
                                    Guid ID = (Guid)GUID_Request4BenefitMaster;
                                    var row = rows.FirstOrDefault(b => b.GUID_Request4BenefitMaster == ID);

                                    if (row != null)
                                    {
                                        row.NextApponintmentDate = nextAppointmentDate;
                                        row.Save();

                                        updateCount++;
                                    }
                                }
                            }

                            session1.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            session1.RollbackTransaction();
                            MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (updateCount > 0)
                        {
                            // Set appointment date for the selected user
                            MessageBox.Show("Appointment date successfully booked for the selected people", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    appointmentDate = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printSimpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.SelectedRowsCount > 0)
                {
                    if (MessageBox.Show("Are you sure you want to print acknowledgment letter for the selected people?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // create PBMSDocuments directory
                        string path = Properties.Settings.Default.PBMSPath + "\\Letters";

                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);

                        int noOfDocumentsRequired = 0, noOfDocumentsSubmitted = 0;

                        //session1.BeginTransaction();

                        XPQuery<DoucmentMaster> documentMasters = this.session1.Query<DoucmentMaster>();
                        XPQuery<Request4BenefitDocs> request4BenefitDocs = this.session1.Query<Request4BenefitDocs>();

                        IQueryable<DoucmentMaster> documentsSubmitted = null;
                        IQueryable<DoucmentMaster> documentsRequired = null;

                        try
                        {
                            if (documentMasters != null)
                            {
                                XFont font = new XFont("Arial", 9, XFontStyle.Regular);
                                XFont fontUnderline = new XFont("Arial", 9, XFontStyle.Underline);
                                XSolidBrush textColor = XBrushes.Black;
                                XStringFormat textPosition = XStringFormats.TopLeft;

                                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                                {
                                    var GUID_Request4BenefitMaster = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "GUID_Request4BenefitMaster");
                                    if (GUID_Request4BenefitMaster != null)
                                    {
                                        XPQuery<Request4BenefitMaster_New> rows = this.session1.Query<Request4BenefitMaster_New>();
                                        Guid ID = (Guid)GUID_Request4BenefitMaster;
                                        var row = rows.FirstOrDefault(b => b.GUID_Request4BenefitMaster == ID);

                                        if (row != null)
                                        {
                                            documentsSubmitted = from bd in request4BenefitDocs
                                                                 join dm in documentMasters on bd.ID_DocumentMaster.ID_DocumentMaster equals dm.ID_DocumentMaster
                                                                 where bd.GUID_Request4BenefitMaster.GUID_Request4BenefitMaster == ID
                                                                 select dm;

                                            noOfDocumentsSubmitted = documentsSubmitted.Count();

                                            switch (row.ID_BenefitType.ID_BenefitType)
                                            {
                                                case "DT":
                                                    documentsRequired = documentMasters.Where(dr => dr.DeathBeneift == true);
                                                    break;
                                                case "LE":
                                                    documentsRequired = documentMasters.Where(dr => dr.LegacyBenefit == true);
                                                    break;
                                                case "MP":
                                                    documentsRequired = documentMasters.Where(dr => dr.MissingPerson == true);
                                                    break;
                                                case "NS":
                                                    documentsRequired = documentMasters.Where(dr => dr.NSITF == true);
                                                    break;
                                                case "PD":
                                                    documentsRequired = documentMasters.Where(dr => dr.Disability == true);
                                                    break;
                                                case "PA":
                                                    documentsRequired = documentMasters.Where(dr => dr.PreAct == true);
                                                    break;
                                                case "RT":
                                                    //var a = (from ds in documentsSubmitted select ds.ID_DocumentMaster).ToList();
                                                    //var b = from dm in documentMasters
                                                    //        where !a.Contains(dm.ID_DocumentMaster)
                                                    //        select dm;

                                                    documentsRequired = documentMasters.Where(dr => dr.Retirement == true);
                                                    break;
                                                case "TL":
                                                    documentsRequired = documentMasters.Where(dr => dr.LossOfEmployment == true);
                                                    break;
                                                case "VL":
                                                    documentsRequired = documentMasters.Where(dr => dr.VoluntaryContribution == true);
                                                    break;
                                            }

                                            List<DoucmentMaster> outstandingDocuments = (List<DoucmentMaster>)documentsRequired.ToList();

                                            if (noOfDocumentsSubmitted > 0)
                                            {
                                                foreach (DoucmentMaster document in documentsSubmitted)
                                                {
                                                    if (outstandingDocuments.Contains(document))
                                                        outstandingDocuments.Remove(document);
                                                }
                                            }

                                            noOfDocumentsRequired = outstandingDocuments.Count();

                                            PdfDocument pdfDocument = new PdfDocument();
                                            pdfDocument.Info.Title = "Acknowledgment Letter";
                                            pdfDocument.Info.Author = "Simplex Business Solutions Limited";
                                            pdfDocument.Info.CreationDate = DateTime.Now;
                                            pdfDocument.Info.Creator = "Pension Benefit Management System";
                                            pdfDocument.Info.Subject = "Acknowledgment Letter";

                                            PdfPage pdfPage = pdfDocument.AddPage();

                                            XGraphics xGraphics = XGraphics.FromPdfPage(pdfPage);

                                            // write the name, address & date
                                            /*xGraphics.DrawString(row.Name, font, textColor, new XRect(10, 10, pdfPage.Width, pdfPage.Height), textPosition);
                                            xGraphics.DrawString("Your Address", font, textColor, new XRect(10, 20, pdfPage.Width, pdfPage.Height), textPosition);*/
                                            xGraphics.DrawString(string.Format("{0:dd-MM-yyyy}", DateTime.Now), font, textColor, new XRect(10, 80, pdfPage.Width, pdfPage.Height), textPosition);
                                            xGraphics.DrawString(string.Format("Dear {0}", row.Name), font, textColor, new XRect(10, 100, pdfPage.Width, pdfPage.Height), textPosition);

                                            // write the subject
                                            xGraphics.DrawString("ACKNOWLEDGMENT LETTER", fontUnderline, textColor, new XRect(10, 120, pdfPage.Width, pdfPage.Height), textPosition);

                                            // write the letter content
                                            xGraphics.DrawString("Thank you for submitting the following documents:", font, textColor, new XRect(10, 140, pdfPage.Width, pdfPage.Height), textPosition);

                                            int lastTopPosition = 120, sn = 0;

                                            if (noOfDocumentsSubmitted > 0)
                                            {
                                                lastTopPosition += 20;
                                                sn = 1;
                                                foreach (DoucmentMaster document in documentsSubmitted)
                                                {
                                                    xGraphics.DrawString(string.Format("{0}. {1}", sn, document.DocumentMaster), font, textColor, new XRect(40, lastTopPosition, pdfPage.Width, pdfPage.Height), textPosition);
                                                    lastTopPosition += 10;
                                                    sn++;
                                                }
                                            }

                                            lastTopPosition += 20;

                                            if (outstandingDocuments.Count() == documentsRequired.Count() && documentsRequired.Count() == 0)
                                            {
                                                lastTopPosition += 20;
                                                xGraphics.DrawString(string.Format("We acknowledge that you have completed the initial documentation for processing of your benefit today {0:dd-MM-yyyy}", DateTime.Now), font, textColor, new XRect(10, lastTopPosition, pdfPage.Width, pdfPage.Height), textPosition);
                                            }
                                            else
                                            {
                                                lastTopPosition += 20;
                                                xGraphics.DrawString("We are expecting you to bring the remaining documents which are:", font, textColor, new XRect(10, lastTopPosition, pdfPage.Width, pdfPage.Height), textPosition);

                                                if (noOfDocumentsRequired > 0)
                                                {
                                                    lastTopPosition += 20;
                                                    sn = 1;
                                                    foreach (DoucmentMaster document in outstandingDocuments)
                                                    {
                                                        xGraphics.DrawString(string.Format("{0}. {1}", sn, document.DocumentMaster), font, textColor, new XRect(40, lastTopPosition, pdfPage.Width, pdfPage.Height), textPosition);
                                                        lastTopPosition += 10;
                                                        sn++;
                                                    }
                                                }

                                                lastTopPosition += 20;
                                                xGraphics.DrawString(string.Format("You have been booked on the {0:dd-MM-yyyy} in order to proceed with your benefit processing.", row.NextApponintmentDate), font, textColor, new XRect(10, lastTopPosition, pdfPage.Width, pdfPage.Height), textPosition);
                                            }

                                            // write the conclusion
                                            lastTopPosition += 20;
                                            xGraphics.DrawString("Thanks", font, textColor, new XRect(10, lastTopPosition, pdfPage.Width, pdfPage.Height), textPosition);
                                            lastTopPosition += 20;
                                            xGraphics.DrawString("PFA Name", font, textColor, new XRect(10, lastTopPosition, pdfPage.Width, pdfPage.Height), textPosition);

                                            path = Properties.Settings.Default.PBMSPath + "\\Letters";
                                            path += string.Format("\\Acknowledgment_Letter_{0}_{1:DD-MM-YYY_HH_mm_ss}.pdf", row.PIN, DateTime.Now);

                                            pdfDocument.Save(path);

                                            xGraphics = null;
                                            pdfPage = null;
                                            pdfDocument = null;

                                            Process.Start(path);
                                        }
                                    }
                                }

                                //session1.CommitTransaction();
                            }
                        }
                        catch (Exception ex)
                        {
                            //session1.RollbackTransaction();
                            MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changeSimpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.SelectedRowsCount > 0)
                {
                    var GUID_Request4BenefitMaster = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "GUID_Request4BenefitMaster");
                    if (GUID_Request4BenefitMaster != null)
                    {
                        XPQuery<Request4BenefitMaster_New> rows = this.session1.Query<Request4BenefitMaster_New>();
                        Guid ID = (Guid)GUID_Request4BenefitMaster;
                        var row = rows.FirstOrDefault(b => b.GUID_Request4BenefitMaster == ID);

                        if (row != null)
                        {
                            MyPage myPage = new MyPage();

                            myPage.PIN = row.PIN;
                            myPage.ShowDialog();
                            myPage = null;
                        }

                        row = null;
                        rows = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void insertSimpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                MyPage myPage = new MyPage();

                myPage.ShowDialog();
                myPage = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteSimpleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.SelectedRowsCount > 0)
                {
                    if (MessageBox.Show("Are you sure you want to delete the selected people?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int updateCount = 0;

                        session1.BeginTransaction();

                        try
                        {
                            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                            {
                                var GUID_Request4BenefitMaster = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], "GUID_Request4BenefitMaster");
                                if (GUID_Request4BenefitMaster != null)
                                {
                                    XPQuery<Request4BenefitMaster_New> rows = this.session1.Query<Request4BenefitMaster_New>();
                                    Guid ID = (Guid)GUID_Request4BenefitMaster;
                                    var row = rows.FirstOrDefault(b => b.GUID_Request4BenefitMaster == ID);

                                    if (row != null)
                                    {
                                        // remove the children data first
                                        var children = this.session1.Query<Request4BenefitDocs>().Where(item => item.GUID_Request4BenefitMaster.GUID_Request4BenefitMaster == ID).ToList();
                                        if (children.Count > 0)
                                        {
                                            foreach (var child in children)
                                                child.Delete();
                                        }

                                        // delete the master
                                        row.Delete();
                                        updateCount++;
                                    }
                                }
                            }

                            session1.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            session1.RollbackTransaction();
                            MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (updateCount > 0)
                        {
                            // Set appointment date for the selected user
                            MessageBox.Show("Selected people have been deleted", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BrowseDocument_Load(object sender, EventArgs e)
        {
            this.benefitTypeLookUpEdit.SelectionStart = 0;
        }
    }
}