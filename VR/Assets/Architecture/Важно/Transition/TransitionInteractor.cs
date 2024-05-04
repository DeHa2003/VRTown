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

        private Color startColor = new Color(0, 0, 0, 0);
        private Color toColor = Color.black;

        private bool isTransition = false;

        public void SetData(IPlayerEvents playerEvents)
        {
            this.playerEvents = playerEvents;
            this.playerEvents.OnCreatePlayer += GetData;
        }

        private void GetData(GamePlayer player)
        {
            playerFadeScreen = player;
            playerMove = player;
            FadeScreen(0, Color.black);
        }

        public void TransitionToScene(int sceneNumber)
        {
            sceneTransition = sceneNumber;
            LoadScene();
        }

        public void TransitionToScene_Fade(int sceneNumber)
        {
            sceneTransition = sceneNumber;
            FadeScreen(0.5f, toColor, LoadScene);
        }

        public void TransitionToPosition(Vector3 vector)
        {
            posToMove = vector;
            Teleport();
        }

        public void TransitionToPosition_Fade(Vector3 vector)
        {
            posToMove = vector;
            FadeScreen(0.5f, toColor, Teleport);
        }

        public void FadeScreen(float duration, Color color, Action OnFinish = null)
        {
            if(playerFadeScreen == null)
            {
                Debug.Log("Игрок не найден - " + this.ToString());
            }

            playerFadeScreen.Fade(duration, color, OnFinish);
        }

        private void LoadScene()
        {
            SceneManager.LoadScene(sceneTransition);
        }

        private void Teleport()
        {
            playerMove.TeleportToPosition(posToMove);
            FadeScreen(0.5f, startColor);
        }
    }
}

public interface IPlayerTransitionInteractorProvider : IInterface
{
    void FadeScreen(float duration, Color color, Action OnFinish = null);
    void TransitionToScene(int sceneNumber);
    void TransitionToPosition(Vector3 vector);
    void TransitionToScene_Fade(int sceneNumber);
    void TransitionToPosition_Fade(Vector3 vector);
}

public interface IPlayerTransitionInteractorProvider_SetData : IInterface
{
    void SetData(IPlayerEvents playerEvents);
}
