using ElectronRazorPage;
using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame250 : BaseFramePage
    {
        private static int NextNumber;

        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }
        public string TextForFrame { get; set; }


        public Frame250(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame250", "Frame227", mediaHelper, studentDataReader, NextNumber)
        {
        }

        public override IActionResult OnPostGoToNextPage()
        {
            return RedirectToPage($"Frame252", new { GameType = "Game" });
        }
    }
}