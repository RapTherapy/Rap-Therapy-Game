using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame266Model : BaseFramePage
    {
        public Frame266Model
            (MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame266", "Frame267", mediaHelper, studentDataReader, 267)
        {
        }
    }
}
