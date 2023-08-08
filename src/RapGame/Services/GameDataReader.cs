using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RapGame.Models;
using System.Collections.Generic;
using System.IO;

namespace RapGame.Services
{
    public class GameDataReader
    {
        private readonly AppSettings _appSettings;
        private readonly JsonSerializer _serializer;

        public GameDataReader(AppSettings appSettings,
            JsonSerializer serializer)
        {
            this._appSettings = appSettings;
            this._serializer = serializer;
        }

        public List<Game1Data> GetDataFromGame1()
        {
            var result = GetGameData<List<Game1Data>>("Game1");
            return result;
        }

        public List<Game2Data> GetDataFromGame2()
        {
            var result = GetGameData<List<Game2Data>>("Game2");
            return result;
        }

        public List<Game3Data> GetDataFromGame3()
        {
            var result = GetGameData<List<Game3Data>>("Game3");
            return result;
        }

        public Game4Data GetDataFromGame4()
        {
            var result = GetGameData<Game4Data>("Game4");
            return result;
        }

        public List<Game5Data> GetDataFromGame5()
        {
            var result = GetGameData<List<Game5Data>>("Game5");
            return result;
        }
        public Game6Data GetDataFromGame6()
        {
            var result = GetGameData<Game6Data>("Game6");
            return result;
        }
        public List<Game7Data> GetDataFromGame7()
        {
            var result = GetGameData<List<Game7Data>>("Game7");
            return result;
        }
        public List<Game8Data> GetDataFromGame8()
        {
            var result = GetGameData<List<Game8Data>>("Game8");
            return result;
        }
        public Gameframe184Data GetDataFromGameframe184()
        {
            var result = GetGameData<Gameframe184Data>("Game(Frame184)");
            return result;
        }
        public List<Game9Data> GetDataFromGame9()
        {
            var result = GetGameData<List<Game9Data>>("Game9");
            return result;
        }
        public List<Game11Data> GetDataFromGame11()
        {
            var result = GetGameData<List<Game11Data>>("Game11");
            return result;
        }

        protected string GetGamePath(string relativePath)
        {
            return Path.GetFullPath(
                        Path.Combine(
                            _appSettings.PathToGameFile.BasePath
                            ?? string.Empty,
                            _appSettings.PathToGameFile.Path
                            ?? string.Empty,
                            relativePath))
                    .Replace("\\", "/");
        }

        protected T GetGameData<T>(string key)
        {
            var file = new FileInfo(GetGamePath(key + ".json"));
            T result = default;

            if (file.Exists)
            {
                using StreamReader sr = file.OpenText();
                result = (T)_serializer.Deserialize(sr, typeof(T));
            }

            return result;
        }
    }
}
