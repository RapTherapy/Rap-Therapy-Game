using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame231Model : BaseFramePage
    {
        public Frame231Model
            (MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame231", "Frame232Template", mediaHelper, studentDataReader, 232)
        {
        }
    }
}
