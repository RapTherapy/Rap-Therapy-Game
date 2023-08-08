using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace RapGame.Pages
{
    public class AdminPageModel : BaseFramePage
    {
        private readonly string loginRegex = @"^(?=.*[A-Za-z0-9]$)[A-Za-z][A-Za-z\d.-]{0,19}$";
        private readonly string passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{3,}$";


        private readonly string _pathToAppSettings;
        private readonly AppSettings _appSettings;
        private readonly IStudentDataReader _studentDataReader;

        public List<Student> Students { get; set; }
        public string PathToAssets => _appSettings.AdminData.BasePath;

        public AdminPageModel(
            AppSettings settings,
            MediaHelper mediaHelper,
            IStudentDataReader studentDataReader)
            : base("AdminPage", "Frame1", mediaHelper, studentDataReader)
        {
            _appSettings = settings;
            _pathToAppSettings = Path.Combine(Environment.CurrentDirectory, "appsettings.json");

            _studentDataReader = studentDataReader;

            Students = _studentDataReader.GetStudents().ToList();
        }

        public IActionResult OnPostGetStudent([FromBody] Guid studentId)
        {
            return new JsonResult(_studentDataReader.GetStudent(studentId));
        }

        public IActionResult OnPostSaveUser([FromBody] RequestData requestData)
        {
            if (string.IsNullOrEmpty(requestData.Id))
            {
                _studentDataReader.CreateStudent(requestData.Name, requestData.Password);
            }
            else
            {
                var student = _studentDataReader.GetStudent(Guid.Parse(requestData.Id));

                student.Name = requestData.Name;
                student.Password = requestData.Password;
                _studentDataReader.UpdateStudent(student);
            }

            return new JsonResult(HttpStatusCode.OK);
        }

        public IActionResult OnPostIsUserExist([FromBody] string login)
        {
            if (!Regex.IsMatch(login, loginRegex))
            {
                return new JsonResult(
                    new
                    {
                        Message = "Login incorrect",
                        color = "text-danger",
                    });
            }

            var students = _studentDataReader.GetStudents();

            if (String.IsNullOrEmpty(login))
            {
                return new JsonResult(
                    new
                    {
                        Message = "Login empty",
                        color = "text-danger",
                    });
            }

            if (students.Any(x => x.Name == login))
            {
                return new JsonResult(
                    new
                    {
                        Message = "A user with the same name already exists",
                        color = "text-danger",
                    });
            }

            return new JsonResult(new { Message = "OK", color = "text-success" });
        }

        public IActionResult OnPostIsPasswordValid([FromBody] string password)
        {
            password = password.Trim();

            if (password.Length == 0)
            {
                return new JsonResult(new
                {
                    Message = "The password must contain at least three characters!",
                    color = "text-danger",
                });
            }

            if (!Regex.IsMatch(password, passwordRegex))
            {
                return new JsonResult(new
                {
                    Message = "Password must contains at least one lower case, one upper case, one number and one special character!",
                    color = "text-danger",
                });
            }

            return new JsonResult(new { Message = "OK", color = "text-success" });
        }

        public IActionResult OnPostDeleteUser([FromBody] Guid studentId)
        {
            _studentDataReader.DeleteStudent(studentId);
            return new JsonResult(HttpStatusCode.OK);
        }

        public IActionResult OnPostChangBasePath([FromBody] string basePath)
        {
            if (string.IsNullOrEmpty(basePath))
            {
                return new JsonResult(HttpStatusCode.NotFound);
            }

            var newAdminDataBasePath = Path.GetFullPath(basePath).Replace("\\", "/");

            _appSettings.AdminData.BasePath = newAdminDataBasePath;
            _appSettings.PathToGameFile.BasePath = basePath;
            _appSettings.PathToMediaFileForFrame.BasePath = basePath;
            _appSettings.PathToLicence.BasePath = basePath;

            var json = JsonConvert.SerializeObject(_appSettings, Formatting.Indented);
            System.IO.File.WriteAllText(_pathToAppSettings, json);

            return new JsonResult(HttpStatusCode.OK);
        }
        public IActionResult OnPostBackTheGame()
        {
            return RedirectToPage("Frame3");
        }
    }
    public record RequestData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
