using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;
using System;
using System.Text.Json;

namespace ElectronRazorPage.Pages
{
    public class FrameFaildLicence : BaseFramePage
       
    {
        public CheckLicense _license;
        public FrameFaildLicence(MediaHelper mediaHelper, IStudentDataReader studentDataReader,CheckLicense license) 
            : base("Frame1", "Frame3", mediaHelper, studentDataReader)
        {
            _license = license;
        }

        public override void OnGet()
        {
        }      
    }
}