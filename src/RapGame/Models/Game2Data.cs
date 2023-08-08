using System.Collections.Generic;

namespace RapGame.Models
{
    public class Game2Data
    {
        public int FrameNumber { get; set; }
        public string FrameText { get; set; }
        public string AlternativeFrameText { get; set; }
        public string PathToSound { get; set; }
        public List<Sentence> Sentences { get; set; }
    }

    public class Sentence
    {
        public string SentenceText { get; set; }
        public string LastWord { get; set; }
        public string LastWordTextColor { get; set; }
        public int SentenceDuration { get; set; }
    }
}
