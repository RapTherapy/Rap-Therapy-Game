using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System.Collections.Generic;
using System.Linq;

namespace RapGame.Pages
{
    public class Frame168TemplateModel : BaseFramePage
    {
        private static int NextNumber;
        private static int Counter = 0;
        private static Game8Data CurrentGameData;
        private List<Game8Data> Data;
        public string Strings;

        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }
        public Game8Data GameData;

        public Frame168TemplateModel(MediaHelper mediaHelper,
               GameDataReader gameReader,
               IStudentDataReader studentDataReader) : base("Frame167", "Frame73", mediaHelper, studentDataReader, 179)
        {
            Data = gameReader.GetDataFromGame8();
        }

        public override void OnGet()
        {
            base.OnGet();
            
            NextNumber = FrameNumber + 1;
            GameData = Data[Counter];
            MediaData.PatchToSound = GameData.PathToAdditionalAudio;
            CurrentGameData = GameData;
            var Answer = CurrentGameData.Answers.Where(x => x.IsAnsweredCorrect == true).ToList();
            if(!CurrentGameData.IsTheStartOfaSentence)
            {
                Strings =  Answer.First().Answer + " " + CurrentGameData.Sentence;
            }
            else
            {
                Strings = CurrentGameData.Sentence + " " + Answer.First().Answer;
            }
           
            Counter++;
        }

        public override IActionResult OnPostGoToNextPage()
        {
            //return RedirectToPage("Frame167Template", new { FrameNumber = NextNumber });
            if (Counter >= Data.Count)
            {
                return RedirectToPage("Frame73", new { FrameNumber = 180 });
            }
            else
            {
                return RedirectToPage("Frame167Template", new { FrameNumber = NextNumber });
            }
        }      
    }
}
