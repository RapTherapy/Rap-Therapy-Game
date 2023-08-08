using Newtonsoft.Json;
using RapGame.Models;
using System.IO;

namespace RapGame.Utils
{
    public class MediaHelper
    {
        private readonly AppSettings _appSettings;
        private readonly JsonSerializer _serializer;

        public MediaHelper(
            AppSettings appSettings,
            JsonSerializer serializer)
        {
            _appSettings = appSettings;
            _serializer = serializer;
        }

        public string GetMediaPath(string relativePath)
        {
            return Path.GetFullPath(
                        Path.Combine(
                            _appSettings.PathToMediaFileForFrame.BasePath 
                            ?? string.Empty,
                            _appSettings.PathToMediaFileForFrame.Path
                            ?? string.Empty,
                            relativePath))
                    .Replace("\\", "/");
        }

        public MediaDataForFrames GetMediaData(string key)
        {
            var file = new FileInfo(GetMediaPath(key + ".json"));
            MediaDataForFrames result = new();

            if (file.Exists)
            {
                using StreamReader sr = file.OpenText();
                result = (MediaDataForFrames)_serializer.Deserialize(sr, typeof(MediaDataForFrames));
            }

            return result;
        }
    }
}
