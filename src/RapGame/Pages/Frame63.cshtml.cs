using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame63Model : BaseFramePage
    {
        public Frame63Model(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader) 
            : base("Frame63", "Frame64", mediaHelper, studentDataReader)
        {
        }
    }
}
