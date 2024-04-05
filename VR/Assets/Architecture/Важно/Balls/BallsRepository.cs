using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class BallsRepository : Repository
    {
        private const string KEY = "BALLS_COUNT_KEY";

        public int countOpenBalls { get; set; }

        public override void Initialize()
        {
            countOpenBalls = PlayerPrefs.GetInt(KEY, 3);
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(KEY, countOpenBalls);
        }
    }
}
