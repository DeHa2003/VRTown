

using Lessons.Architecture;
using System;
using UnityEngine;

namespace Lessons.Architecture
{
    public delegate void OnChangedScore(int value);
    public class FootballInteractor : Interactor, IFootballInteractorProvider, IFootballInteractorProvider_Data, IFootballInteractorProvider_SetData
    {
        public event OnChangedScore OnChangedScoreCommandA;
        public event OnChangedScore OnChangedScoreCommandB;
        public int ScoreCommandA { get; private set; }
        public int ScoreCommandB { get; private set; }

        private IFootballGoal goalA;
        private IFootballGoal goalB;
        private Transform posSpawn;
        private FootballBall footballBall;


        public void SetData(IFootballGoal goalA, IFootballGoal goalB, FootballBall ball, Transform posSpawnBall)
        {
            this.goalA = goalA;
            this.goalB = goalB;
            this.posSpawn = posSpawnBall;
            this.footballBall = ball;
        }

        public void ActivateGame()
        {
            goalA.AddAction(AddScoreCommandA);
            goalB.AddAction(AddScoreCommandB);
        }

        public void DeactivateGame()
        {
            goalA.RemoveAction(AddScoreCommandA);
            goalB.RemoveAction(AddScoreCommandB);
        }

        public void SpawnFootballBall()
        {
            footballBall.transform.position = posSpawn.position;
            footballBall.DeactivateImpulse();
        }

        private void AddScoreCommandA()
        {
            ScoreCommandA += 1;
            SpawnFootballBall();
            OnChangedScoreCommandA?.Invoke(ScoreCommandA);
            Debug.Log("Команда A забила!!!");
        }

        private void AddScoreCommandB()
        {
            ScoreCommandB += 1;
            SpawnFootballBall();
            OnChangedScoreCommandB?.Invoke(ScoreCommandB);
            Debug.Log("Команда B забила!!!");
        }
    }
}

public interface IFootballInteractorProvider : IInterface
{
    void ActivateGame();
    void DeactivateGame();
    void SpawnFootballBall();
}

public interface IFootballInteractorProvider_Data : IInterface
{
    event OnChangedScore OnChangedScoreCommandA;
    event OnChangedScore OnChangedScoreCommandB;

    int ScoreCommandA { get; }
    int ScoreCommandB { get; }
}

public interface IFootballInteractorProvider_SetData : IInterface
{
    void SetData(IFootballGoal goalA, IFootballGoal goalB, FootballBall ball, Transform posSpawnBall);
}

public interface IFootballGoal
{
    void AddAction(Action onObjectTriggered);
    void RemoveAction(Action onObjectTriggered);
}
