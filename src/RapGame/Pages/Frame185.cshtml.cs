using ElectronRazorPage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Services;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame185Model : BaseFramePage
    {
        private static int NextNumber;

        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }
        public TextModel TextData;

        public Frame185Model(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame185", "Frame184", mediaHelper, studentDataReader)
        {
        }

        public override void OnGet()
        {
            base.OnGet();
            NextNumber = FrameNumber + 1;
        }

        public override IActionResult OnPostGoToNextPage()
        {
            var currentStudent = HttpContext.Session.GetStudentFromSession("StudentJSON");
            currentStudent.GameProgress.MysticMicsCounter=currentStudent.GameProgress.MysticMicsCounter+3;
            HttpContext.Session.CreateSession("StudentJSON", currentStudent, _studentDataReader);

            return RedirectToPage("Frame35Template", new { FrameNumber = 186 });
        }
    }
}

