using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Services;
using RapGame.Utils;

namespace RapGame.Pages.AdditionalContent
{
    public class GameModel : BaseFramePage
    {
        [BindProperty(SupportsGet = true)]
        public Data Data { get; set; }
        public string Message;
        public string BackToFrame;

        public GameModel(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame4", "Frame", mediaHelper, studentDataReader)
        {
        }

        public override void OnGet()
        {   
            
            Message = GetMessageForFrame(Data.MessageFor);
            BackToFrame = Data.BackTo;
        }

        public string GetMessageForFrame(string messageFor)
        {
            switch (messageFor)
            {
                case "TimeIsOut":
                    return "Oh no, you ran out of time.";
                default:
                    return "";
            }
        }
        public override IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("StudentJSON");
            return RedirectToPage("../Frame3");
        }
    } 
   

    public class Data
    {
        public string MessageFor { get; set; }
        public string BackTo { get; set; }
    }
}
