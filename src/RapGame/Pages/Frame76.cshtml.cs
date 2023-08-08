using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame76Model : BaseFramePage
    {
        public Frame76Model(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame76", "Frame77", mediaHelper, studentDataReader)
        {
        }
    }
}
