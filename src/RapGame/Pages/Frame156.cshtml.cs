using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Utils;

namespace RapGame.Pages
{
    public class Frame156Model : BaseFramePage
    {
        public static int intCurrnetIndex;
        public Frame156Model(MediaHelper mediaHelper, IStudentDataReader studentDataReader) : base("Frame156", "Frame154", mediaHelper, studentDataReader)
        {
        }

        public override void OnGet()
        {
        }

        public override IActionResult OnPostGoToNextPage()
        {
            return base.OnPostGoToNextPage();
        }
    }
}