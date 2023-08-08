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
    public class Frame189TemplateModel : BaseFramePage
    {
        private static GameSetting GameSetting;
        private static List<Game9Data> UsedGameData = new List<Game9Data>();

        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }
        public List<Game9Data> GameData;
        public bool TwoGameCompleted { get; set; }

        public Frame189TemplateModel(MediaHelper mediaHelper, GameDataReader gameReader, IStudentDataReader studentDataReader) : base("Frame189", "Frame80Template", mediaHelper, studentDataReader)
        {
            GameData = gameReader.GetDataFromGame9();
        }

        public override void OnGet()
        {
            //base.OnGet();
            CurrentStudent = HttpContext.Session.GetStudentFromSession("StudentJSON");
            TwoGameCompleted = FirstTwoGamesCompleted();
            GameSetting = new GameSetting();            
            if(CurrentStudent.GameProgress.Game9.IsCurrentGame9 != true)
            {
                CurrentStudent.GameProgress.Game9.IsCurrentGame9 = true;
                HttpContext.Session.CreateSession("StudentJSON", CurrentStudent, _studentDataReader);
            }

            GameSetting.FrameNumber = FrameNumber + 2;

            for (int i = 0; i < GameData.Count; i++)
            {
                if (CurrentStudent.GameProgress.Game9.Emotion[i])
                {
                    GameData[i].IsEmoteSelected = true;
                }
            }
        }
        private bool FirstTwoGamesCompleted()
        {   
           for(int i= 0; i < 2; i++)
            {
                if (CurrentStudent.GameProgress.Game9.Emotion[i]==false)
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
            
           
            if (data.IsPageContainAdditionalContent)
            {
                HttpContext.Session.CreateSessionGameSetting("GameSetting", GameSetting);
                return RedirectToPage("AdditionalContent/AdditionalContentPageGame9", GameSetting);
            }
            else
            {
                HttpContext.Session.CreateSessionGameSetting("GameSetting", GameSetting);
                return RedirectToPage("Frame190Template", GameSetting);
            }
        }
    }

   
}
