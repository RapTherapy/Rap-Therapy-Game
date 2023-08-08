using System.Collections.Generic;

namespace RapGame.Models
{
    public class Game8Data
    {
        public string Sentence { get; set; }
        public bool IsTheStartOfaSentence { get; set; }
        public string PathToImage { get; set; }
        public string PathToAudio { get; set; }
        public string PathToAdditionalAudio { get; set; }
        public List<Answers> Answers { get; set; } = new List<Answers>();
    }

    public class Answers
    {
        public string Answer { get; set; }
        public bool IsAnsweredCorrect { get; set; }
        public string AlternativMessageForIncorrectAnswer { get; set; }
    }
}
