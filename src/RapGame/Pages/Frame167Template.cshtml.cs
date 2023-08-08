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
    public class Frame167TemplateModel : BaseFramePage
    {
        private static int NextNumber;
        private static int Counter = 0;
        private static Game8Data CurrentGameData;
        private List<Game8Data> Data;

        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }
        public Game8Data GameData;

        public Frame167TemplateModel(MediaHelper mediaHelper,
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
            CurrentGameData = GameData;
            MediaData.PatchToSound = GameData.PathToAudio;


            Counter++;
        }

        public override IActionResult OnPostGoToNextPage()
        {
            if(Counter < Data.Count+1)
            {
                return RedirectToPage("Frame168Template", new { FrameNumber = NextNumber });
            }
            else
            {
                return RedirectToPage("Frame73", new { FrameNumber = 180 });
            }
        }

        public IActionResult OnPostIsAnswerCorrect([FromBody] string answer)
        {
            var CurrentAnswer = CurrentGameData.Answers.Find(x => x.Answer == answer);
            var Result = new { IsCorrect = CurrentAnswer.IsAnsweredCorrect, Message = (string.IsNullOrEmpty(CurrentAnswer.AlternativMessageForIncorrectAnswer) ? "Think and try again" : CurrentAnswer.AlternativMessageForIncorrectAnswer) };

            return new JsonResult(Result);
        }
    }
}
