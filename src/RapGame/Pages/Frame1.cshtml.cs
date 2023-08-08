using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;
using System;
using System.Text.Json;

namespace ElectronRazorPage.Pages
{
    public class IndexModel : BaseFramePage
       
    {
        public CheckLicense _license;
        public IndexModel(MediaHelper mediaHelper, IStudentDataReader studentDataReader,CheckLicense license) 
            : base("Frame1", "Frame3", mediaHelper, studentDataReader)
        {
            _license = license;
        }

        public override void OnGet()
        {
        }

        public IActionResult OnGetCheckLicence()
        {
            //var licence = _license.GetLicence("GameLicense");
            //var date = DateTime.Parse(licence.Expired);
            //if (!_license.IsLicenceExpired(date))
            //{
            //    return new JsonResult(true);
            //}
            //else
            //{
            //    return new JsonResult(false);
            //}
            return new JsonResult(true);
        }
    }
}