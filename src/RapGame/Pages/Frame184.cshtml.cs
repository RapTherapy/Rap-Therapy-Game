using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System.Collections.Generic;

namespace RapGame.Pages
{
    public class Frame184Model : BaseFramePage
    {
        public Gameframe184Data Data { get; set; }
        public GameDataReader _gameReader;

        public Frame184Model(MediaHelper mediaHelper, IStudentDataReader studentDataReader, GameDataReader gameReader) : base("Frame184", "Frame185", mediaHelper, studentDataReader)
        {

            _gameReader = gameReader;
            Data = gameReader.GetDataFromGameframe184();
        }
    }
}
