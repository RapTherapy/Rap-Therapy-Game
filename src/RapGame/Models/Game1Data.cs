using System.Collections.Generic;

namespace RapGame.Models
{
    public class Game1Data
    {
        public bool IsGameWithTimer { get; set; }
        public string LeftSideWord { get; set; }
        public string RightSideWord { get; set; }
        public List<Word> Words { get; set; }
        public string TextForFrame { get; set; }
    }

    public class Word
    {
        public string WordId { get; set; }
        public string WordValue { get; set; }
    }
}
