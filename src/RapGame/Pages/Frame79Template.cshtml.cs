using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System.Collections.Generic;
using System.Threading;

namespace RapGame.Pages
{
    public class Frame79TemplateModel : BaseFramePage
    {
        private static GameSetting GameSetting;
        private static List<Game5Data> UsedGameData = new List<Game5Data>();

        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }
        public List<Game5Data> GameData;
        public bool ThreeGameCompleted { get; set; }

        public Frame79TemplateModel(MediaHelper mediaHelper, GameDataReader gameReader, IStudentDataReader studentDataReader) : base("Frame79", "Frame80Template", mediaHelper, studentDataReader)
        {
            GameData = gameReader.GetDataFromGame5();
        }

        public override void OnGet()
        {
            //base.OnGet();
            CurrentStudent = HttpContext.Session.GetStudentFromSession("StudentJSON");
            ThreeGameCompleted = FirstThreeGamesCompleted();
            GameSetting = new GameSetting();            
            if(CurrentStudent.GameProgress.Game5.IsCurrentGame5 != true)
            {
                CurrentStudent.GameProgress.Game5.IsCurrentGame5 = true;
                HttpContext.Session.CreateSession("StudentJSON", CurrentStudent, _studentDataReader);
            }

            GameSetting.FrameNumber = FrameNumber + 1;

            for (int i = 0; i < GameData.Count; i++)
            {
                if (CurrentStudent.GameProgress.Game5.Emotion[i])
                {
                    GameData[i].IsEmoteSelected = true;
                }
            }
        }
        private bool FirstThreeGamesCompleted()
        {   
           for(int i= 0; i < 3; i++)
            {
                if (CurrentStudent.GameProgress.Game5.Emotion[i]==false)
                {
                    return false;
                }
            }
            return true;
        }
        public IActionResult OnPostStartGame(string emotionForRap)
        {   

            var data = GameData.Find(x => x.EmotionForRap == emotionForRap);
            var indexOfData = GameData.FindIndex(x => x.EmotionForRap == emotionForRap);            
            GameSetting.EmotionForRap = emotionForRap;
            GameSetting.IndexOfEmotion = indexOfData;
            if (GameSetting.EmotionForRap == "Excited" || GameSetting.EmotionForRap == "Angry")
            {   
                GameSetting.FrameNumber++;
                HttpContext.Session.CreateSessionGameSetting("GameSetting", GameSetting);
            }
            else
            {
                HttpContext.Session.CreateSessionGameSetting("GameSetting", GameSetting);
            }
           
            if (data.IsPageContainAdditionalContent)
            {
                return RedirectToPage("AdditionalContent/IntroducingPage", GameSetting);
            }
            else
            {
                return RedirectToPage("Frame80Template", GameSetting);
            }
        }
    }

    public class GameSetting
    {
        public int FrameNumber { get; set; }
        public string EmotionForRap { get; set; }

        public int IndexOfEmotion { get; set; }
    }
}
