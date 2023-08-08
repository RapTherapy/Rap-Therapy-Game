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
    public class Frame191TemplateModel : BaseFramePage
    {
        private static GameSetting GameSetting;
        private List<Game9Data> GameList;

        [BindProperty(SupportsGet = true)]
        public GameSetting Setting { get; set; }
        public Game9Data GameData { get; set; }

        public Frame191TemplateModel(MediaHelper mediaHelper, GameDataReader gameReader, IStudentDataReader studentDataReader) : base("Frame191Template", "Frame192Template", mediaHelper, studentDataReader)
        {
            GameList = gameReader.GetDataFromGame9();
        }

        public override void OnGet()
        {          
            CountOfMysticMics = HttpContext.Session.GetStudentFromSession("StudentJSON").GameProgress.MysticMicsCounter;
            GameSetting = Setting;
            GameSetting.FrameNumber += 2;
            GameData = GameList.Find(x => x.EmotionForRap == GameSetting.EmotionForRap);
            MediaData.PatchToSound = GameData.PathToAudioFileFrame191;
            

        }
       
        public override IActionResult OnPostGoToNextPage()
        {
            return RedirectToPage(NextFrameName, GameSetting);
        }
    }
}
