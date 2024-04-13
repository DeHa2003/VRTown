using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lessons.Architecture
{
    public class TransitionInteractor : Interactor, IPlayerTransitionInteractorProvider, IPlayerTransitionInteractorProvider_SetData
    {

        private IPlayerEvents playerEvents;

        private IPlayerFadeScreen playerFadeScreen;
        private IPlayerMove playerMove;

        private Vector3 posToMove;
        private int sceneTransition;

        public void SetData(IPlayerEvents playerEvents)
        {
            this.playerEvents = playerEvents;
            this.playerEvents.OnCreatePlayer += GetData;
        }

        private void GetData(GamePlayer player)
        {
            playerFadeScreen = player;
            playerMove = player;
        }

        public void TransitionToScene(int sceneNumber)
        {
            sceneTransition = sceneNumber;
            FadeScreen(1, LoadScene);
        }

        public void TransitionToPosition(Vector3 vector)
        {
            posToMove = vector;
            FadeScreen(1, Teleport);
        }

        public void FadeScreen(float duration, Action OnFinish = null)
        {
            if(playerFadeScreen == null)
            {
                Debug.Log("Игрок не найден - " + this.ToString());
            }

            playerFadeScreen.Fade(duration, OnFinish);
        }

        private void LoadScene()
        {
            SceneManager.LoadScene(sceneTransition);
        }

        private void Teleport()
        {
            playerMove.TeleportToPosition(posToMove);
        }
    }
}

public interface IPlayerTransitionInteractorProvider : IInterface
{
    void FadeScreen(float duration, Action OnFinish = null);
    void TransitionToScene(int sceneNumber);
    void TransitionToPosition(Vector3 vector);
}

public interface IPlayerTransitionInteractorProvider_SetData : IInterface
{
    void SetData(IPlayerEvents playerEvents);
}
