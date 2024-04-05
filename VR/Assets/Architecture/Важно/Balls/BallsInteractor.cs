using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class BallsInteractor : Interactor
    {
        private BallsRepository repository;

        public int CountOpenBalls => this.repository.countOpenBalls;

        public override void OnCreate()
        {
            base.OnCreate();
            this.repository = Game.GetRepository<BallsRepository>();
        }

        public void AddBalls(object sender, int value)
        {
            this.repository.countOpenBalls += value;
            this.repository.Save();
        }
    }
}
