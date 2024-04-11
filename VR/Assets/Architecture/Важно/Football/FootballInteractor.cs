

using Lessons.Architecture;
using System;
using UnityEngine;

namespace Lessons.Architecture
{
    public delegate void OnChangedScore(int value);
    public class FootballInteractor : Interactor, IDataFootballInteractor
    {
        public event OnChangedScore OnChangedScoreCommandA;
        public event OnChangedScore OnChangedScoreCommandB;
        public int ScoreCommandA { get; private set; }
        public int ScoreCommandB { get; private set; }

        private IFootballGoal goalA;
        private IFootballGoal goalB;
        private IDataFootballInteractor dataFootballInteractor;

        public void SetData(IFootballGoal goalA, IFootballGoal goalB)
        {
            this.goalA = goalA;
            this.goalB = goalB;
        }

        public void Activate()
        {
            goalA.AddAction(AddScoreCommandA);
            goalB.AddAction(AddScoreCommandB);
        }

        public void Deactivate()
        {
            goalA.RemoveAction(AddScoreCommandA);
            goalB.RemoveAction(AddScoreCommandB);
        }

        private void AddScoreCommandA()
        {
            ScoreCommandA += 1;
            OnChangedScoreCommandA?.Invoke(ScoreCommandA);
            Debug.Log("Комманда A забила!!!");
        }

        private void AddScoreCommandB()
        {
            ScoreCommandB += 1;
            OnChangedScoreCommandB?.Invoke(ScoreCommandB);
            Debug.Log("Комманда B забила!!!");
        }
    }
}

public interface IDataFootballInteractor
{
    event OnChangedScore OnChangedScoreCommandA;
    event OnChangedScore OnChangedScoreCommandB;

    int ScoreCommandA { get; }
    int ScoreCommandB { get; }
}

public interface IFootballGoal
{
    void AddAction(Action onObjectTriggered);
    void RemoveAction(Action onObjectTriggered);
}
