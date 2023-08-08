using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System.Collections.Generic;

namespace RapGame.Pages
{
    public class Frame138Model : BaseFramePage
    {
        public  Game6Data Data { get; set; }

        public GameDataReader _gameReader;

        public Frame138Model(MediaHelper mediaHelper, IStudentDataReader studentDataReader, GameDataReader gameReader) : base("Frame138", "Frame139", mediaHelper, studentDataReader)
        {

            _gameReader = gameReader;
            Data = gameReader.GetDataFromGame6();
        }

        public IActionResult OnPostGetAnswers()
        {   
            var test = new JsonResult(_gameReader.GetDataFromGame6());
            return test;
        }

    }
}
