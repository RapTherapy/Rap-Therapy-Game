using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame150Model : BaseFramePage
    {
        public Frame150Model(MediaHelper mediaHelper, IStudentDataReader studentDataReader) : base("Frame150", "Frame4Template", mediaHelper, studentDataReader, 151)
        {
        }
    }
}
