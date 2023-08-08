using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame77Model : BaseFramePage
    {
        public Frame77Model(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame77", "Frame78", mediaHelper, studentDataReader)
        {
        }
    }
}
