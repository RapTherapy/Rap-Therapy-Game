using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame73Model : BaseFramePage
    {

        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }
        private static int NextNumber;
        public string json;

        public Frame73Model(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame73", "Frame35Template", mediaHelper, studentDataReader, 75)
        {
            string[] MainPhoto = { MediaData.PathsToImages[2], MediaData.PathsToImages[3] };
            json = JsonConvert.SerializeObject(MainPhoto);
        }
        public override void OnGet()
        {   
            base.OnGet();
            NextNumber = FrameNumber + 1;
            var currentStudent = HttpContext.Session.GetStudentFromSession("StudentJSON");
            var currentCountOfMysticMics = currentStudent.GameProgress.MysticMicsCounter + 5;
            currentStudent.GameProgress.MysticMicsCounter = currentCountOfMysticMics;
            if (NextNumber == 112 || NextNumber == 145 || NextNumber == 181)
            {
                MediaData.PatchToSound = "Sounds/frame 111.wav";
                HttpContext.Session.CreateSession("StudentJSON", currentStudent);
            }
            else
            {
                HttpContext.Session.CreateSession("StudentJSON", currentStudent, _studentDataReader);
            }
              
        }

        public override IActionResult OnPostGoToNextPage()
        {
            if (NextNumber == 112)
            {
                return RedirectToPage("Frame35Template", new { FrameNumber = NextNumber });
            }
            if (NextNumber == 145)
            {
                return RedirectToPage("Frame35Template", new { FrameNumber = 145 });
            }
            if (NextNumber == 181)
            {
                return RedirectToPage("Frame35Template", new { FrameNumber = 181 });
            }
            if (NextNumber == 244)
            {
                return RedirectToPage("Frame35Template", new { FrameNumber = 245 });
            }
            else
            {
                return RedirectToPage("Frame35Template", new { FrameNumber = 75 });
            }

           
        }
    }
}