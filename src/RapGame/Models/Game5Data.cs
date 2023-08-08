using System.Collections.Generic;

namespace RapGame.Models
{
    public class Game5Data
    {
        public string EmotionForRap { get; set; }
        public string RhymeScheme  { get; set; }
        public bool IsEmoteSelected { get; set; }
        public bool EnlargedText { get; set; }
        public int SentenceDuration { get; set; }
        public string PathToAudioFileFrame80 { get; set; }
        public string PathToAudioFileFrame82 { get; set; }
        public string PathToAudioFileFrame83 { get; set; }
        public bool IsPageContainAdditionalContent { get; set; }
        public string PathToImages { get; set; }
        public AdditionalContent AdditionalContent { get; set; } = new AdditionalContent();
        public List<Sentence> Sentences { get; set; }
    }

    public class AdditionalContent
    {
        public int RowNumberWithRefOnAdditionalContent { get; set; }
        public int CountOfFrameWithAdditionalContent { get; set; }
    }
}
