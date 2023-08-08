using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Utils;

namespace RapGame.Helper
{
    public abstract class BaseFramePage : PageModel
    {
        public string CurrentFrameName { get; private set; }
        public string NextFrameName { get; private set; }
        public int NextFrameNumber { get; set; }
        public MediaHelper MediaHelper { get; set; }
        public MediaDataForFrames MediaData { get;  set; }
        public Student CurrentStudent { get; set; }
        public int CountOfMysticMics { get;  set; }

        private string CurrentUrl;
        private string LoginFrame;
        protected readonly IStudentDataReader _studentDataReader;

        public BaseFramePage(
            string currentFrameName,
            string nextFrameName,
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader,
            int nextFrameNumber = 0) : base()
        {
            CurrentFrameName = currentFrameName;
            NextFrameName = nextFrameName;
            NextFrameNumber = nextFrameNumber;
            MediaHelper = mediaHelper;
            this._studentDataReader = studentDataReader;
            MediaData = mediaHelper.GetMediaData(currentFrameName);
            CountOfMysticMics = 0;
            CurrentUrl = string.Empty;
            LoginFrame = "Frame3";
        }

        protected BaseFramePage(string v1, string v2, MediaHelper mediaHelper)
        {
            MediaHelper = mediaHelper;
        }

        public virtual void OnGet()
        {
            CurrentUrl = (Request.Path + Request.QueryString).TrimStart('/');
            var Student = HttpContext.Session.GetStudentFromSession("StudentJSON");
            Student.GameProgress.LastFrame = CurrentUrl.Split('?')[0];
            if (CurrentUrl.Contains("="))
            {
                Student.GameProgress.ParametrValue = int.Parse(CurrentUrl.Split('=')[1]);
            }
            HttpContext.Session.CreateSession("StudentJSON", Student, _studentDataReader);

            GetMysticMicsCount();
            GetCurrentUser();
        }

        public virtual IActionResult OnPostGoToNextPage()
        {
            return NextFrameNumber == 0 ? RedirectToPage(NextFrameName) : RedirectToPage(NextFrameName, new { FrameNumber = NextFrameNumber });
        }

        private void GetMysticMicsCount()
        {
            CountOfMysticMics = HttpContext.Session.GetStudentFromSession("StudentJSON").GameProgress.MysticMicsCounter;
        }

        private void GetCurrentUser()
        {
            CurrentStudent = HttpContext.Session.GetStudentFromSession("StudentJSON");
        }

        public void GetNewMediaData(int FrameNumber)
        {
            MediaData = MediaHelper.GetMediaData($"Frame{FrameNumber}");
        }

        public virtual IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("StudentJSON");
            return RedirectToPage(LoginFrame);
        }
    }
}
