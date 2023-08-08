using ElectronRazorPage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System.Collections.Generic;
using System.Reflection;

namespace RapGame.Pages
{
    public class Frame29Model : BaseFramePage
    {
        private List<Game2Data> Data;
        private static bool isNextPageGame = true;
        private static int currentFrame;

        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }
        public bool isPageHaveFullText;
        public Game2Data GameData;
        public string test;

        public Frame29Model(
            MediaHelper mediaHelper,
            GameDataReader gameReader, 
            IStudentDataReader studentDataReader) 
            : base("Frame29", "Frame34Template", mediaHelper, studentDataReader)
        {
            Data = gameReader.GetDataFromGame2();          
        }

        public override void OnGet()
        {
            base.OnGet();

            GameData = Data.Find(x => x.FrameNumber == FrameNumber);
            isPageHaveFullText = isNextPageGame;
            currentFrame = GameData.FrameNumber;            
            GetNewMediaData(currentFrame);

            if (isNextPageGame == false)
            {
                MediaData.PatchToSound = "Sounds/frame 30.wav";
            }
        }

        public override IActionResult OnPostGoToNextPage()
        {
            if (isNextPageGame)
            {
                isNextPageGame = false;
                return RedirectToPage("Frame29", new { FrameNumber = currentFrame });               
            }
            else
            {
                isNextPageGame = true;
                return RedirectToPage($"Frame34Template", new { FrameNumber = currentFrame + 5 });
            }
        }
    }
}
