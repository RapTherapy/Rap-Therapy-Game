using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame55Model : BaseFramePage
    {
        public Frame55Model(
            MediaHelper mediaHelper, 
            IStudentDataReader studentDataReader) 
            : base("Frame55", "Frame56", mediaHelper, studentDataReader)
        {
        }
    }
}

