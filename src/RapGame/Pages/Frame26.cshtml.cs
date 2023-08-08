using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame26Model : BaseFramePage
    {
        public Frame26Model(
            MediaHelper mediaHelper, 
            IStudentDataReader studentDataReader) 
            : base("Frame26", "Frame25Template", mediaHelper, studentDataReader, 27)
        {
        }
    }
}
