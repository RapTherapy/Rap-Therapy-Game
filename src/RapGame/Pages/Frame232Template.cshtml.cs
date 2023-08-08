using ElectronRazorPage;
using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame232TemplateModel : BaseFramePage
    {
        private static int NextNumber;

        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }
        public string TextForFrame { get; set; }


        public Frame232TemplateModel(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame232Template", "Frame237", mediaHelper, studentDataReader, NextNumber)
        {
        }

        public override void OnGet()
        {
            base.OnGet();

            TextForFrame = Texts.GetTextForframe(FrameNumber).Text;
            NextNumber = FrameNumber + 1;
            GetNewMediaData(FrameNumber);
        }

        public override IActionResult OnPostGoToNextPage()
        {
            if (Texts.IfTemplateExists(NextNumber))
            {
    
                return RedirectToPage("Frame232Template", new { FrameNumber = NextNumber });
            }
            if(NextNumber == 243)
            {
                return RedirectToPage("Frame73", new { FrameNumber = NextNumber });
            }            
            else
            {
                return RedirectToPage($"Frame237", new { GameType = "Training" });
            }
        }
    }
}
