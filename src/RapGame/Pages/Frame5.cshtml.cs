using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace ElectronRazorPage.Pages
{
    public class Frame5Model : BaseFramePage
    {
        public Frame5Model(
            MediaHelper mediaHelper, 
            IStudentDataReader studentDataReader) 
            : base("Frame5", "Frame6", mediaHelper, studentDataReader)
        {
        }
    }
}
