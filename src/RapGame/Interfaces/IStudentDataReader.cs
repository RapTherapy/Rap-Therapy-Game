using RapGame.Models;
using System;
using System.Collections.Generic;

namespace RapGame.Interfaces
{
    public interface IStudentDataReader
    {
        IEnumerable<Student> GetStudents();
        Student CreateStudent(string login, string password);
        bool ChangePassword(Guid id, string newPassword);
        Student? GetStudent(Guid id);
        void UpdateStudent(Student currentStudent);
        void DeleteStudent(Guid id);
    }
}
