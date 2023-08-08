using System.Collections.Generic;

namespace RapGame.Models
{
    public class Game11Data
    {
        public string GameType { get; set; }
        public List<GameData> GameData { get; set; }
    }

    public class GameData
    {
        public string Line { get; set; }
        public List<string> WordsHints  { get; set; }
    }
}
