using ElectronRazorPage;
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

namespace RapGame.Pages
{
    public class Frame69TemplateModel : BaseFramePage
    {
        private static int NextNumber;

        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }
        public Game4Data GameData;


        public Frame69TemplateModel(MediaHelper mediaHelper,
            GameDataReader gameReader,
            IStudentDataReader studentDataReader) : base("Frame69", "Frame73", mediaHelper, studentDataReader, 73)
        {
            GameData = gameReader.GetDataFromGame4();
        }

        public IActionResult OnGetGetAudioFiles()
        {
            var res = new List<string>();

            foreach(var item in GameData.PathToSoundFile )
            {
                res.Add(MediaHelper.GetMediaPath(item));
            }

            return new JsonResult(res.ToArray());
        }

        public override void OnGet() 
        {
            base.OnGet();
            NextNumber = FrameNumber + 1;
        }

        public override IActionResult OnPostGoToNextPage()
        {
            if (NextNumber != 73)
            {
                return RedirectToPage("Frame69Template", new { FrameNumber = NextNumber });
            }
            else
            {
                return RedirectToPage("Frame73");
            }
        }
    }
}
