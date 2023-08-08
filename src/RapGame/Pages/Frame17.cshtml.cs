using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System.Collections.Generic;

namespace ElectronRazorPage.Pages
{
    public class Frame17Model : BaseFramePage
    {
        private static List<Game1Data> Data;
        private static int NextNumber;
        private static int Count=0;

        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }
        public Game1Data GameData;
        public bool IsGameWithTimer;
        public int PageVisits;

        public Frame17Model(
            MediaHelper mediaHelper, 
            GameDataReader gameReader, 
            IStudentDataReader studentDataReader) 
            : base("Frame17", "Frame18", mediaHelper, studentDataReader)
        {
            Data = gameReader.GetDataFromGame1();
        }

        public override void OnGet()
        {
            base.OnGet();
            NextNumber = FrameNumber + 1;

            if(FrameNumber == 19)
            {
                GetNewMediaData(FrameNumber);
                Count++;
                IsGameWithTimer = true;
                PageVisits = Count;
            }
            else
            {
                IsGameWithTimer = false;
            }

            GameData = Data.Find(x => x.IsGameWithTimer == IsGameWithTimer);
        }

        public override IActionResult OnPostGoToNextPage()
        {
            return RedirectToPage($"Frame{NextNumber}"); 
        }
    }
}
