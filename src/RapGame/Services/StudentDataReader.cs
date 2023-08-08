using Newtonsoft.Json;
using RapGame.Interfaces;
using RapGame.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RapGame.Services
{
    public class StudentDataReader : IStudentDataReader
    {
        private readonly AppSettings _appSettings;
        private readonly JsonSerializer _serializer;

        private string UsersDirectoryPath =>
            Path.Combine(_appSettings.AdminData.BasePath ?? String.Empty,
                         _appSettings.AdminData.Path ?? String.Empty).Replace("\\", "/");

        public StudentDataReader(
            AppSettings appSettings,
            JsonSerializer serializer)
        {
            this._appSettings = appSettings;
            this._serializer = serializer;
        }

        public Student CreateStudent(string login, string password)
        {
            //Console.WriteLine("{0} {1} {2}", login, password, UsersDirectoryPath);
            if (GetStudents().Any(x => x.Name == login)
                || string.IsNullOrEmpty(login)
                || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = login,
                Password = password,
            };

            FileInfo file = new FileInfo(
                Path.Combine(UsersDirectoryPath, $"{student.Id}.json"));

            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }

            using var sw = file.CreateText();
            _serializer.Serialize(sw, student);

            return student;
        }

        public IEnumerable<Student> GetStudents()
        {
            DirectoryInfo dir = new DirectoryInfo(UsersDirectoryPath);
            if (dir.Exists)
            {
                FileInfo[] files =
                    dir.GetFiles($"{Guid.Empty.ToString().Replace("0", "?")}.json");

                foreach (var file in files)
                {
                    using StreamReader sr = file.OpenText();
                    var student = (Student)_serializer.Deserialize(sr, typeof(Student));

                    yield return student;
                }
            }
        }

        public void UpdateStudent(Student student)
        {
            FileInfo file = new FileInfo(
                Path.Combine(UsersDirectoryPath, $"{student.Id}.json"));

            if (!file.Exists)
            {
                return;
            }

            using (var sw = file.CreateText())
            {
                _serializer.Serialize(sw, student);
            }
        }

        public bool ChangePassword(Guid id, string? newPassword)
        {

            var student = GetStudent(id);
            //student.Name = String.IsNullOrEmpty(newLogin) ? student.Name : newLogin;
            student.Password = String.IsNullOrEmpty(newPassword) ? student.Password : newPassword;

            UpdateStudent(student);

            return true;
        }

        public Student? GetStudent(Guid id)
        {
            FileInfo file = new FileInfo(
                Path.Combine(UsersDirectoryPath, $"{id}.json"));

            if (!file.Exists)
            {
                return null;
            }

            using StreamReader sr = file.OpenText();
            var student = (Student)_serializer.Deserialize(sr, typeof(Student));

            return student;
        }

        public void DeleteStudent(Guid id)
        {
            FileInfo file = new FileInfo(
                Path.Combine(UsersDirectoryPath, $"{id}.json"));

            file.Delete();
        }
    }
}
