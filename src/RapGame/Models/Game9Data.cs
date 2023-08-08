using System.Collections.Generic;

namespace RapGame.Models
{
    public class Game9Data
    {
        public string EmotionForRap { get; set; }
        public string RhymeScheme  { get; set; }
        public bool IsEmoteSelected { get; set; }
        public string PathToAudioFileFrame190 { get; set; }
        public string PathToAudioFileFrame191 { get; set; }
        public string PathToAudioFileFrame192 { get; set; }
        public bool IsPageContainAdditionalContent { get; set; }
        //public AdditionalContent AdditionalContent { get; set; } = new AdditionalContent();
        public List<Words> Words { get; set; }
        public int[]ArrayAnswerId { get; set; }
    }
}
