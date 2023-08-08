namespace ElectronRazorPage
{
    public class TextModel
    {
        public int FrameNumber { get; set; }
        public string Text { get; set; }
    }
    public class TextModelFrame25: TextModel
    {
        public string Header { get; set; }
    }

    public class TextModelFrame136 : TextModel
    {
        public string Header { get; set; }
    }
}
