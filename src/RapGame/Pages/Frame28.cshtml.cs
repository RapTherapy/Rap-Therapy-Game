using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame28Model : BaseFramePage
    {
        public Frame28Model(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame28", "Frame29", mediaHelper, studentDataReader, 29)
        {
        }
    }
}
