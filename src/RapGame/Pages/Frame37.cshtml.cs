using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame37Model : BaseFramePage
    {
        public Frame37Model(
            MediaHelper mediaHelper, 
            IStudentDataReader studentDataReader) 
            : base("Frame37", "Frame29", mediaHelper, studentDataReader, 38)
        {
        }
    }
}