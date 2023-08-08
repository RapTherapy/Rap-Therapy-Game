using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame46Model : BaseFramePage
    {
        public Frame46Model(
            MediaHelper mediaHelper, 
            IStudentDataReader studentDataReader) 
            : base("Frame46", "Frame29", mediaHelper, studentDataReader, 47)
        {
        }
    }
}
