namespace RapGame.Models
{
    public class MediaDataForFrames
    {
        public MediaDataForFrames()
        {
            PatchToSound = string.Empty;
            Title = string.Empty;
            PathsToImages = new[] { "", "", "", "", "" };
        }

        public string PatchToSound { get; set; }
        public string Title { get; set; }
        public string[] PathsToImages { get; set; }
        public string PatchToAdditionalSound { get; set; }
    }
}
