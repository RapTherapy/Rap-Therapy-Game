using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame135Model : BaseFramePage
    {
        public Frame135Model(MediaHelper mediaHelper, IStudentDataReader studentDataReader) : base("Frame135", "Frame136",  mediaHelper , studentDataReader,136)
        {
        }

        public override void OnGet()
        {
            base.OnGet();
            if (CurrentStudent.GameProgress.Game5.IsCurrentGame5 != false)
            {
                CurrentStudent.GameProgress.Game5.IsCurrentGame5 = false;
                HttpContext.Session.CreateSession("StudentJSON", CurrentStudent, _studentDataReader);
            }
        }
    }
}