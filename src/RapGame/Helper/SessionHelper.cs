using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Pages;

namespace RapGame.Helper
{
    public static class SessionHelper
    {
        public static void CreateSession (this ISession session, string key , Student student)
        {            
            session.SetString(key, JsonConvert.SerializeObject(student));
        }

        public static void CreateSession(this ISession session, string key, Student student, IStudentDataReader studentDataReader)
        {
            session.SetString(key, JsonConvert.SerializeObject(student));
            studentDataReader.UpdateStudent(student);
        }
        public static Student GetStudentFromSession(this ISession session, string key)
        {    
            var student = session.GetString(key);
            return student == null ? new Student(): JsonConvert.DeserializeObject<Student>(student);
        }
        public static void CreateSessionGameSetting(this ISession session, string key, GameSetting gameSetting)
        {
            session.SetString(key, JsonConvert.SerializeObject(gameSetting));
        }
        public static GameSetting GetGameSettingFromSession(this ISession session, string key)
        {
            var student = session.GetString(key);
            return  JsonConvert.DeserializeObject<GameSetting>(student);
        }
    }
}
