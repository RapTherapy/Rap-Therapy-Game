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
    public class Frame82TemplateModel : BaseFramePage
    {
        private static GameSetting GameSetting;
        private List<Game5Data> GameList;

        [BindProperty(SupportsGet = true)]
        public GameSetting Setting { get; set; }
        public Game5Data GameData { get; set; }

        public Frame82TemplateModel(MediaHelper mediaHelper, GameDataReader gameReader, IStudentDataReader studentDataReader) : base("Frame82", "Frame83Template", mediaHelper, studentDataReader)
        {
            GameList = gameReader.GetDataFromGame5();
        }

        public override void OnGet()
        {
            CountOfMysticMics = HttpContext.Session.GetStudentFromSession("StudentJSON").GameProgress.MysticMicsCounter;
            GameSetting = Setting;
            GameSetting.FrameNumber += 1;
            GameData = GameList.Find(x => x.EmotionForRap == GameSetting.EmotionForRap);
            MediaData.PatchToSound = GameData.PathToAudioFileFrame82;

        }

        public override IActionResult OnPostGoToNextPage()
        {
            return RedirectToPage(NextFrameName, GameSetting);
        }
    }
}
