using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace ElectronRazorPage.Pages
{
    public class Frame136Model : BaseFramePage
    {
        private static int NextNumber;


        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }
        public string TextForFrame { get; set; }
        public string HeaderForFrame { get; set; }


        public Frame136Model(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame136", "Frame137", mediaHelper, studentDataReader)
        {
        }

        public override void OnGet()
        {
            base.OnGet();

            var Data = (TextModelFrame136)Texts.GetTextForframe(FrameNumber);
            TextForFrame = Data.Text;
            HeaderForFrame = Data.Header;

            NextNumber = FrameNumber+1;
            GetNewMediaData(FrameNumber);
        }

        public override IActionResult OnPostGoToNextPage()
        {

            if (Texts.IfTemplateExists(NextNumber))
            {
                return RedirectToPage("Frame136", new { FrameNumber = NextNumber });
            }
                else
            {
                return RedirectToPage($"Frame{NextNumber}", new { FrameNumber});
            }
        }
    }
}
