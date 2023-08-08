using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame78Model : BaseFramePage
    {
        public Frame78Model(
            MediaHelper mediaHelper, 
            IStudentDataReader studentDataReader) 
            : base("Frame78", "Frame79Template", mediaHelper, studentDataReader, 79)
        {
        }
    }
}
