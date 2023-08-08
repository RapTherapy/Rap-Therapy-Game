using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System.Collections.Generic;

namespace RapGame.Pages
{
    public class Frame80TemplateModel : BaseFramePage
    {
        private static GameSetting GameSetting;
        private List<Game5Data> GameList;

        [BindProperty(SupportsGet = true)]
        public GameSetting Setting { get; set; }
        public Game5Data GameData { get; set; }

        public Frame80TemplateModel(MediaHelper mediaHelper, GameDataReader gameReader, IStudentDataReader studentDataReader) : base("Frame80", "Frame81Template", mediaHelper, studentDataReader)
        {
            GameList = gameReader.GetDataFromGame5();
        }

        public override void OnGet()
        {
            CountOfMysticMics = HttpContext.Session.GetStudentFromSession("StudentJSON").GameProgress.MysticMicsCounter;
            GameSetting = Setting;
            GameSetting.FrameNumber += 1;

            GameData = GameList.Find(x => x.EmotionForRap == GameSetting.EmotionForRap);

            //if(GameSetting.EmotionForRap == "Excited" || GameSetting.EmotionForRap == "Angry")
            //{
            //    HttpContext.Session.CreateSessionGameSetting("GameSetting", GameSetting);
            //}

            MediaData.PatchToSound = GameData.PathToAudioFileFrame80;
        }

        public override IActionResult OnPostGoToNextPage()
        {
            return RedirectToPage(NextFrameName, GameSetting);
        }
    }
}
