using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Utils;
using System;
using System.Linq;

namespace ElectronRazorPage.Pages
{
    public class YourDetailsModel : BaseFramePage
    {
        private AppSettings AppSettings;

        public YourDetailsModel(
            IStudentDataReader studentDataReader, 
            AppSettings appSettings, 
            MediaHelper mediaHelper) 
            : base("Frame3", "Frame4Template", mediaHelper, studentDataReader, 4)
        {
            AppSettings = appSettings;
        }
        public override void OnGet()
        {
            HttpContext.Session.Remove("StudentJSON");
        }

        public IActionResult OnPostLogin([FromBody] LoginData loginData)
        {
            Student student;
            string Path = null;
            loginData.Login = loginData.Login.Trim();
            if (loginData.Login.Contains(" "))
            {
                return new JsonResult(new { PathToRedirect = Path, ErrorMessage = "Strip white spaces at the login" });
            }
            if (IsUserAdmin(loginData.Login, loginData.Password))
            {
                HttpContext.Session.Remove("StudentJSON");
                Path = "AdminPage";
            }

            if (IsUserExist(loginData.Login, loginData.Password, out student))
            {
                HttpContext.Session.CreateSession("StudentJSON", student);
                if (!student.GameProgress.Game5.IsCurrentGame5 && !student.GameProgress.Game9.IsCurrentGame9)
                {
                    Path = String.IsNullOrEmpty(student.GameProgress.LastFrame) ? "Frame4Template?FrameNumber=4" : $"{student.GameProgress.LastFrame}?FrameNumber={student.GameProgress.ParametrValue}";
                }
                else
                {
                    if (student.GameProgress.Game5.IsCurrentGame5)
                    {
                        var finishedGame = true;
                        for (int i = 0; i < student.GameProgress.Game5.Emotion.Length; i++)
                        {
                            if (student.GameProgress.Game5.Emotion[i] == false)
                            {
                                finishedGame = false;
                                break;
                            }

                        }
                        if (finishedGame)
                        {
                            Path = $"Frame135";
                        }
                        else
                        {
                            Path = $"Frame79Template?FrameNumber={GetFrameNumberGame5(student)}";
                        }
                    }
                    else
                    {
                        if (student.GameProgress.Game9.IsCurrentGame9)
                        {
                            var finishedGame = true;
                            for (int i = 0; i < student.GameProgress.Game9.Emotion.Length; i++)
                            {
                                if (student.GameProgress.Game9.Emotion[i] == false)
                                {
                                    finishedGame = false;
                                    break;
                                }

                            }
                            if (finishedGame)
                            {
                                Path = $"Frame225";
                            }
                            else
                            {
                                Path = $"Frame189Template?FrameNumber={GetFrameNumberGame9(student)}";
                            }
                        }
                    }
                }

              
            }

            return new JsonResult(new { PathToRedirect = Path, ErrorMessage = "Invalid login or password" });
        }

        private int GetFrameNumberGame5( Student student)
        { 
            int counter = 0 ;
            for(int i = 0; i < student.GameProgress.Game5.Emotion.Length; i++)
            {
                if (student.GameProgress.Game5.Emotion[i] == true)
                {
                    counter++;
                }
            }           
            return 79 + counter * 8;
        }

        private int GetFrameNumberGame9(Student student)
        {
            int counter = 0;
            for (int i = 0; i < student.GameProgress.Game9.Emotion.Length; i++)
            {
                if (student.GameProgress.Game9.Emotion[i] == true)
                {   

                    counter++;
                }
            }
            return 189 + counter * 8;
        }

        private bool IsUserExist(string username, string password, out Student student)
        {
            username = username.Trim();

            var Students = _studentDataReader.GetStudents();
            student = Students.FirstOrDefault(x => x.Name == username && x.Password == password);
            return Students.Any(x => x.Name == username && x.Password == password);
        }

        private bool IsUserAdmin(string username, string password)
        {
            return AppSettings.AdminData.Login == username && AppSettings.AdminData.Password == password;
        }
    }

    public class LoginData
    {
        public string Login { get; set; }   
        public string Password { get; set; }    
    }
}
