using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System.Collections.Generic;

namespace RapGame.Pages
{
    public class Frame269Model : BaseFramePage
    {
        public Gameframe184Data Data { get; set; }
        public GameDataReader _gameReader;
        public int countOf—olumns = 16;

        public Frame269Model(MediaHelper mediaHelper, IStudentDataReader studentDataReader, GameDataReader gameReader) : base("Frame269", "Frame185", mediaHelper, studentDataReader)
        {

            _gameReader = gameReader;
          
        }
    }
}
