using ElectronRazorPage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System.Collections.Generic;

namespace RapGame.Pages.AdditionalContent
{
    public class AdditionalContentPageGame9Model : BaseFramePage
    {
        private static GameSetting GameSetting;
        [BindProperty(SupportsGet = true)]
        public GameSetting Setting { get; set; }
        

        public AdditionalContentPageGame9Model(MediaHelper mediaHelper, GameDataReader gameReader, IStudentDataReader studentDataReader) : base("Frame204", "Frame81Template", mediaHelper, studentDataReader)
        {

        }

        public override void OnGet()
        {
            GameSetting = Setting;
        }

        public override IActionResult OnPostGoToNextPage()
        {
            return RedirectToPage("../Frame190Template", GameSetting);
        }
    }
}
