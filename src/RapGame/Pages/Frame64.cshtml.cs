using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame64Model : BaseFramePage
    {
        public Frame64Model(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame64", "Frame22", mediaHelper, studentDataReader, 65)
        {
        }
    }
}
