using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FHIRcastAdapter
{
    public partial class IntelliSpaceForm : Form
    {
        public IntelliSpaceForm()
        {
            InitializeComponent();
        }

        public bool init(string iSiteHostname)
        {
            axRadiology1.iSyntaxServerIP = iSiteHostname;
            axRadiology1.ImageSuiteDSN = "iSite";
            axRadiology1.Options = "StentorBackEnd,HideLoginWindow,DissableISSA,HideLogoutButton";
            axRadiology1.Initialize();
            return axRadiology1.Initialized;
        }

        public string loadExam(string patientID, string accessionNumber, string Org)
        {
            string ExamID = axRadiology1.FindExam(accessionNumber, patientID, Org);
            string canvasPageID = axRadiology1.OpenCanvasPage(ExamID, "", true, true, true);
            axRadiology1.Visible = true;
            return canvasPageID;
        }

        public bool closeExam(string canvasPageID)
        { 
            return axRadiology1.CloseCanvasPage(canvasPageID, true);
        }

        public bool login(string username, string password, string site)
        {
            if (axRadiology1.Login(username, password, site, "", ""))
            {
                axRadiology1.Visible = true;
                return true;
            }
            else
            {
                MessageBox.Show("Login Error : " + axRadiology1.GetLastErrorCode());
                return false;
            }
        }

        public bool logout()
        {
            return axRadiology1.Logout();
            
        }

    }
}
