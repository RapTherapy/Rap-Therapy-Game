using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace ElectronRazorPage.Pages
{
    public class Frame25Model : BaseFramePage
    {
        private static int NextNumber;


        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }
        public string TextForFrame { get; set; }
        public string HeaderForFrame { get; set; }


        public Frame25Model(
            MediaHelper mediaHelper, 
            IStudentDataReader studentDataReader) 
            : base("Frame25", "Frame26", mediaHelper, studentDataReader)
        {
        }

        public override void OnGet()
        {
            base.OnGet();

            var Data = (TextModelFrame25)Texts.GetTextForframe(FrameNumber);
                TextForFrame = Data.Text;
            HeaderForFrame = Data.Header;

            NextNumber = FrameNumber + 1;
            GetNewMediaData(FrameNumber);
        }

        public override IActionResult OnPostGoToNextPage()
        {
            return RedirectToPage($"Frame{NextNumber}");
        }
    }
}