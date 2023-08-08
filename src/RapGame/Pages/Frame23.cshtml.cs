using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame23Model : BaseFramePage
    {
        public Frame23Model(
            MediaHelper mediaHelper, 
            IStudentDataReader studentDataReader) 
            : base("Frame23", "Frame24", mediaHelper, studentDataReader, 24)
        {
        }
    }
}

