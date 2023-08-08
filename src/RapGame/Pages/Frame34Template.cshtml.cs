using ElectronRazorPage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Services;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame34TemplateModel : BaseFramePage
    {
        private static int NextNumber;

        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }
        public TextModel TextData;

        public Frame34TemplateModel(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame34Template", "Frame35Template", mediaHelper, studentDataReader)
        {
        }

        public override void OnGet()
        {
            base.OnGet();
            var currentStudent = HttpContext.Session.GetStudentFromSession("StudentJSON");
            currentStudent.GameProgress.MysticMicsCounter++;
            HttpContext.Session.CreateSession("StudentJSON", currentStudent, _studentDataReader);
            if (FrameNumber == 34 || FrameNumber == 43 || FrameNumber == 52 || FrameNumber == 162)
            {
                TextData = Texts.GetTextForframe(FrameNumber);
                GetNewMediaData(FrameNumber);
            }
            if (FrameNumber == 85 || FrameNumber == 101 || FrameNumber == 93 || FrameNumber == 109 || FrameNumber == 117 || FrameNumber == 147 || FrameNumber == 162)
            {
                TextData = Texts.GetTextForframe(61);
                GetNewMediaData(85);
            }
            else
            {
                TextData = Texts.GetTextForframe(61);
                GetNewMediaData(61);
            }

            NextNumber = FrameNumber + 1;
        }

        public override IActionResult OnPostGoToNextPage()
        {          
            return RedirectToPage("Frame35Template" , new { FrameNumber = NextNumber });            
        }
    }
}
