using System.Collections.Generic;

namespace RapGame.Models
{
    public class Game4Data
    {
        public  List<string>PathToSoundFile { get; set; }
        public List<Couplet> Couplet { get; set; }
        public List<Word> Word { get; set; }
    }

    public class Couplet
    {
        public int CoupletNumber { get; set; }
        public int CoupletDuration { get; set; }
        public List<Line> Line { get; set; }
    }

    public class Line
    {
        public int LineId { get; set; }
        public string Text { get; set; }
    }
}
