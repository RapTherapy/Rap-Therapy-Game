using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System;
using System.Collections.Generic;

namespace RapGame.Pages
{
    public class Frame190TemplateModel : BaseFramePage
    {
        private static GameSetting GameSetting;
        private List<Game9Data> GameList;

        [BindProperty(SupportsGet = true)]
        public GameSetting Setting { get; set; }
        public Game9Data GameData { get; set; }

        public Frame190TemplateModel(MediaHelper mediaHelper, GameDataReader gameReader, IStudentDataReader studentDataReader) : base("Frame190", "Frame81Template", mediaHelper, studentDataReader)
        {
            GameList = gameReader.GetDataFromGame9();
        }

        public override void OnGet()
        {
            GetNewMediaData(Int32.Parse(CurrentFrameName.Substring(CurrentFrameName.Length-3)));
            CountOfMysticMics = HttpContext.Session.GetStudentFromSession("StudentJSON").GameProgress.MysticMicsCounter;
            GameSetting = Setting;
            GameSetting.FrameNumber += 1;
            GameData = GameList.Find(x => x.EmotionForRap == GameSetting.EmotionForRap);
            MediaData.PatchToSound = GameData.PathToAudioFileFrame190;

        }

        public IActionResult OnPostGetAnswers()
        {
            GameData = GameList.Find(x => x.EmotionForRap == GameSetting.EmotionForRap);
            MediaData.PatchToSound = GameData.PathToAudioFileFrame190;
            var test = GameData.ArrayAnswerId;
            var arrayOfAnswer = new JsonResult(GameData.ArrayAnswerId);
            return arrayOfAnswer;
        }

        public override IActionResult OnPostGoToNextPage()
        {
            return RedirectToPage(NextFrameName, GameSetting);
        }
    }
}
