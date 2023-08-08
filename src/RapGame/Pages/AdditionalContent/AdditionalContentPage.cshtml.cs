using ElectronRazorPage;
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
    public class AdditionalContentPageModel : BaseFramePage
    {
        private static GameSetting GameSetting;
        private static Game5Data Game5Data;
        private static int Counter = 0;


        [BindProperty(SupportsGet = true)]
        public GameSetting Setting { get; set; }
        public string TextForFrame { get; set; }

        private List<Game5Data> GameList;

        public AdditionalContentPageModel(MediaHelper mediaHelper, GameDataReader gameReader, IStudentDataReader studentDataReader) : base("Frame79", "Frame81Template", mediaHelper, studentDataReader)
        {
            GameList = gameReader.GetDataFromGame5();
        }

        public override void OnGet()
        {
            GameSetting = Setting;
            Game5Data = GameList.Find(x => x.EmotionForRap == GameSetting.EmotionForRap);

            Counter++;
            TextForFrame = Game5Data.AdditionalContent.CountOfFrameWithAdditionalContent == 2 ? (Counter == 1 ? Texts.GetTextForframe(107).Text : Texts.GetTextForframe(108).Text) : Texts.GetTextForframe(124).Text;
            if(Game5Data.AdditionalContent.CountOfFrameWithAdditionalContent == 2 )              
            {
                if(Counter == 1)
                {
                    MediaData.PatchToSound = "Sounds/frame 107.wav";
                }
                else
                {
                    MediaData.PatchToSound = "Sounds/frame 108.wav";
                }
            }
            else
            {
                MediaData.PatchToSound = "Sounds/frame 124.wav";
            }
        }

        public override IActionResult OnPostGoToNextPage()
        {
            if(Game5Data.AdditionalContent.CountOfFrameWithAdditionalContent == 2 && Counter == 1)
            {
                return RedirectToPage("AdditionalContentPage", GameSetting);
            }
            else
            {
                Counter = 0;
                return RedirectToPage("GameInAdditionalContentPage", GameSetting);
            }
        }
    }
}
