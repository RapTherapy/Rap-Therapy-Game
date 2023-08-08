using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Utils;
using System.Net;

namespace ElectronRazorPage.Pages
{
    public class Frame4Model : BaseFramePage
    {
        private static int NextNumber;

        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }
        public string TextForFrame { get; set; }


        public Frame4Model(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame4Template", "Frame5", mediaHelper, studentDataReader, NextNumber)
        {
        }

        public override void OnGet()
        {
            base.OnGet();

            TextForFrame = Texts.GetTextForframe(FrameNumber).Text;
            NextNumber = FrameNumber + 1;
            GetNewMediaData(FrameNumber);

        }

        public override IActionResult OnPostGoToNextPage()
        {
            if (Texts.IfTemplateExists(NextNumber))
            {
                return RedirectToPage("Frame4Template", new { FrameNumber = NextNumber });
            }
            else
            {
                if (NextNumber == 22)
                {
                    return RedirectToPage("Frame22", new { FrameNumber = 22 });
                }
                if(NextNumber == 167)
                {
                    return RedirectToPage("Frame167Template", new { FrameNumber = 167 });
                }
                if (NextNumber == 189)
                {
                    return RedirectToPage("Frame189Template", new { FrameNumber = 189 });
                }
                return RedirectToPage($"Frame{NextNumber}", new { FrameNumber = 17 });
            }
        }

        public IActionResult OnPostGoToNextPageFromFeelingBar()
        {
            return new JsonResult(HttpStatusCode.OK);
        }
    }
}
