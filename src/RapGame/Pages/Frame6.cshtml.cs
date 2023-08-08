using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace ElectronRazorPage.Pages
{
    public class Frame6Model : BaseFramePage
    {
        public Frame6Model(
            MediaHelper mediaHelper, 
            IStudentDataReader studentDataReader) 
            : base("Frame6", "Frame4Template", mediaHelper, studentDataReader, 7)
        {
        }
    }
}
