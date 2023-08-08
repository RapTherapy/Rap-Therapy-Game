using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame227Model : BaseFramePage
    {
        public Frame227Model(MediaHelper mediaHelper, IStudentDataReader studentDataReader) : base("Frame227", "Frame35", mediaHelper, studentDataReader, 228)
        {
        }

        public override IActionResult OnPostGoToNextPage()
        {
            var currentStudent = HttpContext.Session.GetStudentFromSession("StudentJSON");
            currentStudent.GameProgress.MysticMicsCounter = currentStudent.GameProgress.MysticMicsCounter - 5;
            HttpContext.Session.CreateSession("StudentJSON", currentStudent);
            return RedirectToPage("Frame35Template", new { FrameNumber = 228 });

        }
    }
}