using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System.Collections.Generic;

namespace RapGame.Pages.AdditionalContent
{
    public class GameInAdditionalContentPageModel : BaseFramePage
    {
        private static GameSetting GameSetting;
        private static Game5Data Game5Data;
        private static int Counter = 0;


        [BindProperty(SupportsGet = true)]
        public GameSetting Setting { get; set; }
        public Game5Data GameDate;
        public int NumberOfRowWithAnswer;

        private List<Game5Data> GameList;

        public GameInAdditionalContentPageModel(MediaHelper mediaHelper, GameDataReader gameReader, IStudentDataReader studentDataReader) : base("Game5additional", "Frame81Template", mediaHelper, studentDataReader)
        {
            GameList = gameReader.GetDataFromGame5();
        }

        public override void OnGet()
        {   
            
            GameSetting = Setting;
            GameDate = GameList.Find(x => x.EmotionForRap == GameSetting.EmotionForRap);
            Game5Data = GameDate;
            if(Game5Data.EmotionForRap == "Excited")
            {
                MediaData.PatchToSound = "Sounds/frame 106.wav";
            }
            else
            {
                MediaData.PatchToSound = "";
            }
           
            Counter++;
        }

        public override IActionResult OnPostGoToNextPage()
        {           
                return RedirectToPage("../Frame22", new { FrameNumber = 110 });          
        }
    }
}
