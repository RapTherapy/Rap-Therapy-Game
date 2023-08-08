using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System.Collections.Generic;

namespace RapGame.Pages
{
    public class Frame56Model : BaseFramePage
    {
        private static List<Game3Data> Data;
        public bool IsMediaReproduced = false;
        public static int intCurrnetIndex;
        public string CurrentAnswer;
        public string CurrentPathToAudio;


        public Frame56Model(
            MediaHelper mediaHelper,
            GameDataReader gameReader,
            IStudentDataReader studentDataReader)
            : base("Frame56", "Frame34Template", mediaHelper, studentDataReader, 61)
        {
            Data = gameReader.GetDataFromGame3();
        }

        public override void OnGet()
        {
            base.OnGet();

            if (intCurrnetIndex < 5)
            {
                CurrentAnswer = Data.ToArray()[intCurrnetIndex].Answer;
                CurrentPathToAudio= Data.ToArray()[intCurrnetIndex].PathToTheAudioFile;
                intCurrnetIndex++;
            }
            else
            {
                intCurrnetIndex = 0;
            }
        }

        public override IActionResult OnPostGoToNextPage()
        {
            if (intCurrnetIndex <= 4)
            {
                return RedirectToPage(CurrentFrameName);
            }
            else
            {
                intCurrnetIndex = 0;
                return RedirectToPage(NextFrameName, new { FrameNumber = NextFrameNumber });
            }

        }
    }
}
