using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame225Model : BaseFramePage
    {
        public Frame225Model
            (MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame225", "Frame226Template", mediaHelper, studentDataReader, 226)
        {

        }
        public override void OnGet()
        {
            base.OnGet();
            if (CurrentStudent.GameProgress.Game9.IsCurrentGame9 != false)
            {
                CurrentStudent.GameProgress.Game9.IsCurrentGame9 = false;
                HttpContext.Session.CreateSession("StudentJSON", CurrentStudent, _studentDataReader);
            }
        }
    }
}
