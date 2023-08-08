using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;
using System;

namespace RapGame.Pages
{
    public class Frame35TemplateModel : BaseFramePage
    {
        private static int NextNumber;

        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }

        public Frame35TemplateModel(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame35", "Frame37", mediaHelper, studentDataReader)
        {
        }

        public override void OnGet()
        {
            base.OnGet();
            NextNumber = FrameNumber + 1;

            if (!String.IsNullOrEmpty(MediaData.PatchToAdditionalSound))
                {

            }
            //GetNewMediaData(FrameNumber);
        }

        public override IActionResult OnPostGoToNextPage()
        {
            if (NextNumber == 54 || NextNumber == 182 || NextNumber == 164 || NextNumber == 182 || NextNumber == 246 || NextNumber == 265)
            {
                return RedirectToPage("Frame22", new { FrameNumber = NextNumber });
            }
            if (NextNumber == 63)
            {
                return RedirectToPage("Frame63");
                //return RedirectToPage("Frame63");
            }
            if (NextNumber == 76)
            {
                return RedirectToPage("Frame76");
            }
            if (NextNumber == 87 || NextNumber == 95 || NextNumber == 103 || NextNumber == 111)
            {
                return RedirectToPage("Frame79Template", new { FrameNumber = NextNumber });
            }
            if (NextNumber == 119)
            {
                return RedirectToPage("Frame135");
            }
            if (NextNumber == 146)
            {
                return RedirectToPage("Frame34Template", new { FrameNumber = 146 });
            }
            if (NextNumber == 148)
            {
                return RedirectToPage("Frame136", new { FrameNumber = 148 });
            }
            if (NextNumber == 113)
            {
                var gameSetting = HttpContext.Session.GetGameSettingFromSession("GameSetting");
                return RedirectToPage("Frame81Template", gameSetting);
            }
            if (NextNumber == 187)
            {
                return RedirectToPage("Frame4Template", new { FrameNumber = 187 });
            }
            if (NextNumber == 196 || NextNumber == 203 || NextNumber == 211 || NextNumber == 218)
            {
                return RedirectToPage("Frame79Template", new { FrameNumber = NextNumber });
            }
            if (NextNumber == 197 || NextNumber == 205 || NextNumber == 213 || NextNumber == 221)
            {
                return RedirectToPage("Frame189Template", new { FrameNumber = NextNumber });
            }
            if (NextNumber == 229)
            {
                return RedirectToPage("Frame226Template", new { FrameNumber = NextNumber });
            }


            return RedirectToPage("Frame25Template", new { FrameNumber = NextNumber });
        }
    }
}
