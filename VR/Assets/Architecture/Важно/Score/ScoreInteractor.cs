using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class ScoreInteractor : Interactor
    {
        public Action OnChangedScore;
        public Action OnChangedMaxScore;
        public int score { get; private set; }
        public int maxScore { get; private set; }

        private ScoreRepository scoreRepository;
        public override void Initialize()
        {
            base.Initialize();
            scoreRepository = Game.GetRepository<ScoreRepository>();
        }

        public override void OnStart()
        {
            base.OnStart();

            maxScore = scoreRepository.maxscore;
            score = 0;
        }

        public void AddScore(object sender, int value)
        {
            score += value;
            OnChangedScore?.Invoke();
            if(score > maxScore)
            {
                maxScore = score;
                OnChangedMaxScore?.Invoke();
                scoreRepository.maxscore = maxScore;
                scoreRepository.Save();
            }
        }
    }
}
