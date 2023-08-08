using ElectronRazorPage;
using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame226TemplateModel : BaseFramePage
    {
        private static int NextNumber;

        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }
        public string TextForFrame { get; set; }


        public Frame226TemplateModel(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame226Template", "Frame227", mediaHelper, studentDataReader, NextNumber)
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
                return RedirectToPage("Frame226Template", new { FrameNumber = NextNumber });
            }
            if(NextNumber == 230)
            {
                return RedirectToPage("Frame22", new { FrameNumber = NextNumber });
            }
            if (NextNumber == 264)
            {
                var Student = HttpContext.Session.GetStudentFromSession("StudentJSON");
                Student.GameProgress.MysticMicsCounter = Student.GameProgress.MysticMicsCounter + 5;
                HttpContext.Session.CreateSession("StudentJSON", Student, _studentDataReader);
                return RedirectToPage("Frame35Template", new { FrameNumber = NextNumber });
            }
            if (NextNumber == 250)
            {
                return RedirectToPage("Frame250");
            }
            else
            {
                return RedirectToPage($"Frame227");
            }
        }
    }
}
