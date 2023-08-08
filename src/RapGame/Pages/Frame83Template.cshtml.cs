using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System.Collections.Generic;

namespace RapGame.Pages
{
    public class Frame83TemplateModel : BaseFramePage
    {
        private static GameSetting GameSetting;
        private List<Game5Data> GameList;

        [BindProperty(SupportsGet = true)]
        public GameSetting Setting { get; set; }
        public Game5Data GameData { get; set; }

        public Frame83TemplateModel(MediaHelper mediaHelper, GameDataReader gameReader, IStudentDataReader studentDataReader) : base("Frame83", "Frame22", mediaHelper, studentDataReader, 84)
        {
            GameList = gameReader.GetDataFromGame5();
        }

        public override void OnGet()
        {
            //base.OnGet();
            
            CountOfMysticMics = HttpContext.Session.GetStudentFromSession("StudentJSON").GameProgress.MysticMicsCounter;
            GameSetting = Setting;
            GameSetting.FrameNumber += 1;

            GameData = GameList.Find(x => x.EmotionForRap == GameSetting.EmotionForRap);
            MediaData.PatchToSound = GameData.PathToAudioFileFrame83;
            var CurrentStudent = HttpContext.Session.GetStudentFromSession("StudentJSON");
            var indexEmotion = HttpContext.Session.GetGameSettingFromSession("GameSetting").IndexOfEmotion;
            CurrentStudent.GameProgress.Game5.Emotion[indexEmotion] = true;
            CurrentStudent.GameProgress.ParametrValue = Setting.FrameNumber;    
            HttpContext.Session.CreateSession("StudentJSON", CurrentStudent, _studentDataReader);
        }

        public override IActionResult OnPostGoToNextPage()
        {
            return RedirectToPage(NextFrameName, new { FrameNumber = GameSetting.FrameNumber });
        }
    }
}
