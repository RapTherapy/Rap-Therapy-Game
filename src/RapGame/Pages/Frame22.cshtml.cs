using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System;

namespace RapGame.Pages
{
    public class Frame22Model : BaseFramePage
    {
        private static int NextNumber;

        [BindProperty(SupportsGet = true)]
        public int FrameNumber { get; set; }

        public Frame22Model(
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("Frame22", "Frame23", mediaHelper, studentDataReader)
        {
        }

        public override void OnGet()
        {
            base.OnGet();

            NextNumber = FrameNumber + 1;

        }

        public IActionResult OnPostNextPage([FromBody] int value)
        {
            string result = $"Frame{NextNumber}";
            string currentvalue = value.ToString();
            if (currentvalue == null)
            {
                currentvalue = "50%";
            }
            else
            {
                currentvalue = value + "0%";
            }

            var currentStudent = HttpContext.Session.GetStudentFromSession("StudentJSON");
            currentStudent.FeelingsReports.Add(new FeelingsReport { FeellingsValue = currentvalue });
            HttpContext.Session.CreateSession("StudentJSON", currentStudent, _studentDataReader);
            if (NextNumber == 85 || NextNumber == 93 || NextNumber == 101 || NextNumber == 109 || NextNumber == 117 || NextNumber == 117)
            {
                result = $"Frame34Template?FrameNumber={NextNumber}";
            }
            if (NextNumber == 111)
            {
                result = $"Frame73?FrameNumber={NextNumber}";
            }
            if (NextNumber == 183)
            {
                result = "Frame184";
            }
            if (NextNumber == 165)
            {
                result = "Frame4Template?FrameNumber=165";
            }
            if (NextNumber == 231)
            {
                result = "Frame231";
            }
            if (NextNumber == 195 || NextNumber == 203 || NextNumber == 211 || NextNumber == 219|| NextNumber == 227)
            {
                result = $"Frame34Template?FrameNumber={NextNumber}";
            }
            if (NextNumber == 247)
            {
                result = $"Frame226Template?FrameNumber={NextNumber}";
            }
            if (NextNumber == 266)
            {
                result = $"Frame266";
            }
            return new JsonResult(result);           
        }
    }
}


