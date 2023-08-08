using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Services;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame20Model : BaseFramePage
    {
        public Frame20Model(
            MediaHelper mediaHelper, 
            IStudentDataReader studentDataReader) 
            : base("Frame20", "Frame22", mediaHelper, studentDataReader, 22)
        {
        }

        public override void OnGet()
        {
            base.OnGet();

            var currentStudent = HttpContext.Session.GetStudentFromSession("StudentJSON");
            currentStudent.GameProgress.MysticMicsCounter++;
            HttpContext.Session.CreateSession("StudentJSON", currentStudent, _studentDataReader);
        }
    }
}
