using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System.Collections.Generic;

namespace RapGame.Pages.Shared
{
    public class IntroducingPageModel : BaseFramePage
    {
        private static GameSetting GameSetting;

        [BindProperty(SupportsGet = true)]
        public GameSetting Setting { get; set; }

        public IntroducingPageModel(MediaHelper mediaHelper, GameDataReader gameReader, IStudentDataReader studentDataReader) : base("Frame79", "Frame80Template", mediaHelper, studentDataReader)
        {
        }

        public override void OnGet()
        {
            //base.OnGet();
            GameSetting = Setting;
        }
    }
}

