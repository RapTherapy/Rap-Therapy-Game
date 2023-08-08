using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame81TemplateModel : BaseFramePage
    {
        private static GameSetting GameSetting;

        [BindProperty(SupportsGet = true)]
        public GameSetting Setting { get; set; }


        public Frame81TemplateModel(MediaHelper mediaHelper, IStudentDataReader studentDataReader) : base("Frame81", "Frame82Template", mediaHelper, studentDataReader)
        { 
        }

        public override void OnGet()
        {
            //base.OnGet();

            GameSetting = Setting;
            GameSetting.FrameNumber += 1;
        }

        public override IActionResult OnPostGoToNextPage()
        {
            return RedirectToPage(NextFrameName, GameSetting);
        }
    }
}
