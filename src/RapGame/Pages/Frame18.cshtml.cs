using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame18Model : BaseFramePage
    {
        public Frame18Model(
            MediaHelper mediaHelper, 
            IStudentDataReader studentDataReader) 
            : base("Frame18", "Frame17", mediaHelper, studentDataReader, 19)
        {
        }
    }
}
