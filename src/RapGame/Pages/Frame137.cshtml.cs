using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame137Model : BaseFramePage
    {
        public string CurrentPathAudio;
        public Frame137Model(MediaHelper mediaHelper, IStudentDataReader studentDataReader) : base("Frame137", "Frame138", mediaHelper, studentDataReader)
        {

        }

        public override void OnGet()
        {
            base.OnGet(); 
            CurrentPathAudio = "Sounds/frame 137 rape.wav";
        }
    }
}
