using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using System;
using Microsoft.Extensions.Options;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System;

namespace RapGame.Pages
{
    public class StudentReportModel : BaseFramePage
    {
        [BindProperty(SupportsGet = true)]
        public Guid StudentId { get; set; }

        public Student Student;

        public StudentReportModel(IStudentDataReader studentDataReader, MediaHelper mediaHelper) : base("StudentReport", "AdminPage", mediaHelper, studentDataReader)
        {
            
        }
        public override void OnGet()
        {
            Student = _studentDataReader.GetStudent(StudentId);
        }
    }
}

/*
namespace RapGame.Pages
{
    public class StudentReportModel : PageModel
    {
        private readonly IStudentDataReader _studentDataReader;
        private readonly PathToMediaFileForFrame PathToMedia;

        public Student Student;
        public MediaDataForFrames MediaData;

        public StudentReportModel(IStudentDataReader studentDataReader, IOptions<PathToMediaFileForFrame> pathToMedia)
        {
            _studentDataReader = studentDataReader;
            PathToMedia = pathToMedia.Value;

            MediaForFramseDataReader reader = new MediaForFramseDataReader();
            MediaData = reader.GetMedia(PathToMedia.BasePath + PathToMedia.Path + "Frame5.json");
        }

        public void OnGet(Guid studentId)
        {
            Student = _studentDataReader.GetStudent(studentId);
        }

        public IActionResult OnPostGoToNextPage()
        {
            return RedirectToPage("AdminPage");
        }
    }
}
*/