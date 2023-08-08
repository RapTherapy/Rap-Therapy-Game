namespace RapGame.Models
{
    public class Game6Data
    {   
        public int BonusTime { get; set; }
        public int Time { get; set; }
        public int CountOfline { get; set; }

        public string[] PathToTheAudioFile { get; set; }

        public Models[] Models { get; set; }
    }

    public class Models
    {
        public string[] Question { get; set; }
        public int[] CorrectAnswer { get; set; }

    }
}
