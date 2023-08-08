using Microsoft.AspNetCore.Mvc;
using RapGame.Helper;
using RapGame.Interfaces;
using RapGame.Models;
using RapGame.Services;
using RapGame.Utils;
using System;
using System.Collections.Generic;

namespace RapGame.Pages
{
    public class Frame154Model : BaseFramePage
    {
        public Game7Data Data { get; set; }
        public static int CurrentFrameId = 0 ;
        public string[] Words; 
        public GameDataReader _gameReader;

        public Frame154Model(MediaHelper mediaHelper, IStudentDataReader studentDataReader, GameDataReader gameReader) : base("Frame154", "Frame156", mediaHelper, studentDataReader)
        {

            _gameReader = gameReader;
            Data = gameReader.GetDataFromGame7().ToArray()[CurrentFrameId];
            Words = Data.String.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        }

        public override void OnGet()
        {
            base.OnGet();
            MediaData.PatchToSound = MediaHelper.GetMediaPath(_gameReader.GetDataFromGame7().ToArray()[CurrentFrameId].PathToTheAudioFile);
        }

        public IActionResult OnPostGetCurrentAnswers()
        {
            var CurrentFileOfAnswer = _gameReader.GetDataFromGame7().ToArray()[CurrentFrameId];
            CurrentFileOfAnswer.PathToTheAdditionalAudioFile = MediaHelper.GetMediaPath(_gameReader.GetDataFromGame7().ToArray()[CurrentFrameId].PathToTheAdditionalAudioFile);
            return  new JsonResult(CurrentFileOfAnswer);
        }
        public override IActionResult OnPostGoToNextPage()
        {
            if(CurrentFrameId <2)
            {
                CurrentFrameId++;
                return base.OnPostGoToNextPage();
            }
            else
            {
                return RedirectToPage($"Frame34Template", new { FrameNumber = 162 });
            }
        }

    }
}

