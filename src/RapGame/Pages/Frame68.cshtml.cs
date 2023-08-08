using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame68Model : BaseFramePage
    {
        public Frame68Model(
            MediaHelper mediaHelper, 
            IStudentDataReader studentDataReader) 
            : base("Frame68", "Frame69Template", mediaHelper, studentDataReader, 69)
        {
        }
    }
}

