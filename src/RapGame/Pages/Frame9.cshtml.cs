using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace ElectronRazorPage.Pages
{
    public class Frame9Model : BaseFramePage
    {
        public Frame9Model(
            MediaHelper mediaHelper, 
            IStudentDataReader studentDataReader) 
            : base("Frame9", "Frame4Template", mediaHelper, studentDataReader, 10)
        {
        }
    }
}
