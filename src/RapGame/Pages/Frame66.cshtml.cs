using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System;
using System.Collections.Generic;

namespace RapGame.Pages
{
    public class Frame66Model : BaseFramePage
    {
        private Random random = new Random();
        private List<int> randomInts = new List<int>();

        public Game4Data GameData;

        public Frame66Model(
            MediaHelper mediaHelper, 
            GameDataReader gameReader, 
            IStudentDataReader studentDataReader) 
            : base("Frame66", "Frame22", mediaHelper, studentDataReader, 67)
        {
            GameData = gameReader.GetDataFromGame4();
            ShuffleWords();
        }

        private void ShuffleWords()
        {
            var newWordOrder = new List<Word>();

            while (randomInts.Count != GameData.Word.Count)
            {
                var randomResult = random.Next(GameData.Word.Count);
                if (!randomInts.Contains(randomResult))
                {
                    randomInts.Add(randomResult);
                    newWordOrder.Add(GameData.Word[randomResult]);
                }
            }

            GameData.Word = newWordOrder;
        }
    }
}
