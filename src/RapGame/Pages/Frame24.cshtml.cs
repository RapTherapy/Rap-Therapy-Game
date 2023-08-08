using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame24Model : BaseFramePage
    {
        public Frame24Model(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader) 
            : base("Frame24", "Frame25Template", mediaHelper, studentDataReader, 25)
        {
        }
    }
}
