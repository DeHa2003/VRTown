using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class ScoreRepository : Repository
    {
        private const string KEY = "MAX_SCORE_KEY";
        public int maxscore { get; set; }
        public override void Initialize()
        {
            maxscore = PlayerPrefs.GetInt(KEY, 0);
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(KEY, maxscore);
        }
    }
}
