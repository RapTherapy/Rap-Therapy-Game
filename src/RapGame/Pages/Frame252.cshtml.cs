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
    public class Frame252Model : BaseFramePage
    {
        static int countOfAttemps;
        private List<Game11Data> _data;

        [BindProperty(SupportsGet = true)]
        public string GameType { get; set; }
        public Game11Data GameData;

        public Frame252Model(MediaHelper mediaHelper,
                            GameDataReader gameReader,
                            IStudentDataReader studentDataReader) : base("Frame237", "Frame232Template", mediaHelper, studentDataReader, 242)
        {
            _data = gameReader.GetDataFromGame11();
        }

        public override void OnGet()
        {
            //base.OnGet();
            GameData = _data.Find(x => x.GameType == GameType);
            countOfAttemps++;
        }

        public IActionResult OnPostGetCountOfattempts()
        {   
            if(countOfAttemps == 1)
            {
                var time = new JsonResult(15);
                return time;
            }
            if(countOfAttemps == 2)
            {
                var time = new JsonResult(20);
                return time;
            }
            if (countOfAttemps == 3)
            {
                var time = new JsonResult(30);
                return time;
            }
            else
            {
                var time = new JsonResult(45);
                return time;
            }
        }
        
        public override IActionResult OnPostGoToNextPage()
        {
            return RedirectToPage("Frame226Template", new { FrameNumber = 262 });
        }
    }
}
