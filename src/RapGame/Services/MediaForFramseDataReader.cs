using ElectronNET.API.Entities;
using Newtonsoft.Json;
using RapGame.Models;
using System.IO;

namespace RapGame.Services
{
    public class MediaForFramseDataReader
    {
        public MediaDataForFrames GetMedia(string pathToFile)
        {
            if (File.Exists(pathToFile))
            {
                using (StreamReader r = new StreamReader(pathToFile))
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<MediaDataForFrames>(json);
                }
            }
            else
            {
                return new MediaDataForFrames() { PatchToSound = "", PathsToImages = new string[] { "", "", "", "", "" } }; 
            }
        } 
    }
}
