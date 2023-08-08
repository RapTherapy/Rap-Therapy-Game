using System;
using System.Collections.Generic;

namespace RapGame.Models
{
    public record Student
    {
        public Student()
        {
            Id = Guid.Empty;
            Name = String.Empty;
            Password = String.Empty;
            GameProgress = new GameProgress();
            FeelingsReports = new List<FeelingsReport>();
           
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public GameProgress GameProgress { get; set; }
        public List<FeelingsReport> FeelingsReports { get; set; }
    }

    public class FeelingsReport
    {
        public string FeellingsValue { get; set; }
    }

    public class GameProgress
    {
        public string LastFrame { get; set; }
        public int ParametrValue { get; set; }
        public int MysticMicsCounter { get; set; }
        public Game5 Game5 { get; set; } = new Game5();
        public Game9 Game9 { get; set; } = new Game9();

    }
    public class Game5
    {  
        public bool IsCurrentGame5 {  get; set; }
        public bool[] Emotion { get; set; } = new bool[5]
        {
            false, false,false,false, false
        };
    }
    public class Game9
    {
        public bool IsCurrentGame9 { get; set; }
        public bool[] Emotion { get; set; } = new bool[5]
        {
            false, false,false,false, false
        };
    }
}
